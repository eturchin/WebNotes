using System;

namespace WebNotes.Entity
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
