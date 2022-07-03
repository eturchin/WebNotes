using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace WebNotes.Models
{
    
    public class NoteModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
    }
   
}
