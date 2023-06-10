namespace NotesApp.Data;

public class ApplicationDBContext : DbContext
{
    public DbSet<Note> Notes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string fullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "NoteAppDB.db");
        optionsBuilder.UseSqlite("FileName=" + fullPath);
    }
}
