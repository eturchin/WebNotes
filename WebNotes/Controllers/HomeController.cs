using System;
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
            var notes = _noteService.GetAllNotes();
            return View("Notes",notes);
        }
        public IActionResult NoteData(Note model)
        { 
            return View("NoteData", model);
        }
        public IActionResult Note(Note model)
        {
            return View("Notes", model);
        }

        [HttpGet]
        public IActionResult GetNote([FromQuery] Guid id)
        {
            var note = _noteService.GetNote(id);
            return View("NoteData", note);
        }

        [HttpPost]
        public IActionResult AddNote(Note model) 
        {
            var nameOfNote = model.Name;
            var note = _noteService.AddNote(new Note
            {
                Name = model.Name,
                Text="Hello World!"
            });
            model.Id = note.Id;
            return nameOfNote == null ? BadRequest("Name cannot be 'NULL'") : RedirectToAction("NoteData");
        }
      
        [HttpPost]
        public IActionResult GetNote(Note model)
        {
            var note = _noteService.GetNote(model.Id);
            model.Name = note.Name;
            model.Id = note.Id;
            model.Text = note.Text;
            return View("NoteData");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
