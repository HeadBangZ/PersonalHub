namespace ProjectHub.Domain.Contracts;

public interface IGenericRepository<T, TId> where T : class where TId : struct
{
    Task<T?> GetAsync(TId id);
    Task<List<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(TId id);
}
