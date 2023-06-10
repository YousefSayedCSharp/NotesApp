namespace NotesApp.InterFaces;

public interface IDataHelper<T>
{
    Task<List<T>> GetAllAsync();
    Task<T> FindAsync(int id);
    Task AddAsync(T model);
    Task UpdateAsync(T model);
    Task RemoveAsync(T model);
}
