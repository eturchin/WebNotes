using Microsoft.EntityFrameworkCore;
using WebNotes.Entity;

namespace WebNotes.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Note> Notes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) 
            : base(dbContextOptions)
        {
        }
    }
}
