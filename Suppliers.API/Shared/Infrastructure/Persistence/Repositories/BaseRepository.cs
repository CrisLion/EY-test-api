using Microsoft.EntityFrameworkCore;
using Suppliers.API.Shared.Domain.Models.Entities;
using Suppliers.API.Shared.Domain.Repositories;
using Suppliers.API.Shared.Infrastructure.Persistence.Configuration;

namespace Suppliers.API.Shared.Infrastructure.Persistence.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseDomainModel
{
    protected readonly ServiceDbContext Context;

    public BaseRepository(ServiceDbContext context)
    {
        Context = context;
    }

    public async Task<IReadOnlyCollection<TEntity>> FindAllAsync()
    {
        return await Context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> FindByIdAsync(int id)
    {
        return await Context.Set<TEntity>().Where(t => t.Id == id).FirstOrDefaultAsync();
    }

    public async Task SaveAsync(TEntity entity)
    {
        await Context.Set<TEntity>().AddAsync(entity);
    }

    public void Modify(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
    }

    public void Remove(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }
}