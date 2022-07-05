using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebNotes.DbContext;
using WebNotes.Entity;

namespace WebNotes.Service
{
    public class NoteService : INoteService
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

        public void RemoveNote(Note note)
        {
            _dbContext.Remove(note); 
            _dbContext.SaveChanges();
        }
        public async Task<Note> UpdateNote(Note note)
        {
            var updatedNote = _dbContext.Update(note);

            await _dbContext.SaveChangesAsync();

            return updatedNote.Entity;
        }

        public Note GetNote(Guid id)
        {

            return _dbContext.Notes.Find(id);
        }
    }
}
