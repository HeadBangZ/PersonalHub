namespace ProjectHub.Domain.Contracts;

public interface IEntityExistenceVerfifier<T, TId>
{
    Task<bool> ExistsAsync(TId entityId);
}
