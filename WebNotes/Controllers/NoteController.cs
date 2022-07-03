using System;
using Microsoft.AspNetCore.Mvc;
using WebNotes.Entity;
using WebNotes.Service;

namespace WebNotes.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var notes = _noteService.GetAllNotes();
            return View(notes);
        }

        [HttpGet]
        public IActionResult GetNote([FromRoute] Guid id)
        {
            var note = _noteService.GetNote(id);

            return View("NoteData", note);
        }

        [HttpPost]
        public IActionResult AddNote(Note note)
        {
            var addedNote = _noteService.AddNote(note);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateNote(Note note)
        {
            var addedNote = _noteService.UpdateNote(note);
            return View("Index");
        }
    }
}