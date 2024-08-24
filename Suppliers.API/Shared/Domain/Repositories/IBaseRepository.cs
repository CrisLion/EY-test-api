using Suppliers.API.Shared.Domain.Models.Entities;

namespace Suppliers.API.Shared.Domain.Repositories;

public interface IBaseRepository<TEntity> where TEntity : BaseDomainModel
{
    Task<IReadOnlyCollection<TEntity>> FindAllAsync();
    Task<TEntity?> FindByIdAsync(int id);
    Task SaveAsync(TEntity entity);
    void Modify(TEntity entity);
    void Remove(TEntity entity);
}