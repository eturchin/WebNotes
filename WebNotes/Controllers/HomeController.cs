using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebNotes.Models;

namespace WebNotes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

            return nameOfNote == null ? BadRequest("Name cannot be 'NULL'") : Note(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
