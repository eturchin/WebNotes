using System;
using System.Threading.Tasks;
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
            _noteService.AddNote(note);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNote(Note note)
        {
            var updatedNote = _noteService.GetNote(note.Id);
            updatedNote.Text = note.Text;
            await _noteService.UpdateNote(updatedNote);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult RemoveNote(Note note)
        {
            var removedNote = _noteService.GetNote(note.Id);
            _noteService.RemoveNote(removedNote); 
            return RedirectToAction("Index");
        }
    }
}