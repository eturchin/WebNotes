using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
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
                Text="Hello World!"
            });
            model.Id = note.Id;
            return nameOfNote == null ? BadRequest("Name cannot be 'NULL'") : Note(model);
        }
      
        [HttpPost]
        public IActionResult GetNote(NoteModel model)
        {
            _noteService.GetNote(model.Id);
            return NoteData(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
