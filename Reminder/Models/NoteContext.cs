using System.Data.Entity;

namespace Reminder.Models
{
    public class NoteContext : DbContext
    {
        public DbSet<Note> NotesTable { get; set; }
    }
}