using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebNotes.Entity;
using WebNotes.Models;
using WebNotes.Service;

namespace WebNotes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NoteService _noteService;

        public HomeController(ILogger<HomeController> logger, NoteService noteService)
        {
            _logger = logger;
            _noteService = noteService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Notes()
        {
            return View();
        }
        public IActionResult NoteData(NoteModel model)
        { 
            return View("NoteData", model);
        }
        public IActionResult Note(NoteModel model)
        {
            return View("Notes", model);
        }

        [HttpPost]
        public IActionResult AddNote(NoteModel model) 
        {
            var nameOfNote = model.Name;
            var note = _noteService.AddNote(new Note
            {
                Name = model.Name,
                Language = "Russki",
                Text = "Ahuennay zametka"
            });
            return nameOfNote == null ? BadRequest("Name cannot be 'NULL'") : Note(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
