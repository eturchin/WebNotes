using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebNotes.Entity;

namespace WebNotes.Service
{
    public interface INoteService
    {
        public List<Note> GetAllNotes();

        public Note AddNote(Note note);

        public Note GetNote(Guid id);
        public void RemoveNote(Note note);
        public Task<Note> UpdateNote(Note note);
    }
}