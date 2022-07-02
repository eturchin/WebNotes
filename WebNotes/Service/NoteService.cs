using System.Collections.Generic;
using System.Linq;
using WebNotes.DbContext;
using WebNotes.Entity;

namespace WebNotes.Service
{
    public class NoteService
    {
        private readonly ApplicationDbContext _dbContext;

        public NoteService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Note> GetAllNotes()
        {
            return _dbContext.Notes.ToList();
        }
        public Note AddNote(Note note)
        {
            var addedNote = _dbContext.Notes.Add(note);
            _dbContext.SaveChanges();
            return addedNote.Entity;
        }
    }
}
