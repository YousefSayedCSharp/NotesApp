namespace NotesApp.Data;

public class NoteEntity : IDataHelper<Note>
{
    private ApplicationDBContext db=MauiProgram.context;

    //public NoteEntity() =>
        //db = MauiProgram.context;
        //db = new ApplicationDbContext();

    public async Task AddAsync(Note model)
    {
        await db.Notes.AddAsync(model);
        await db.SaveChangesAsync();
    }

    public async Task<Note> FindAsync(int id)=>
        await db.Notes.FindAsync(id);

    public async Task<List<Note>> GetAllAsync() =>
        await db.Notes.ToListAsync();

    public async Task RemoveAsync(Note model)
    {
        //await Task.Run(()=>
        db.Notes.Remove(model);
            //);
        await db.SaveChangesAsync();
    }

    public async Task UpdateAsync(Note model)
    {
        //await Task.Run(() => 
        db.Notes.Update(model);
            //);
        await db.SaveChangesAsync();
    }

}
