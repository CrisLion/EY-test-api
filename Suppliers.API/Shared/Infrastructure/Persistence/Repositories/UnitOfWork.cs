using Suppliers.API.Shared.Domain.Repositories;
using Suppliers.API.Shared.Infrastructure.Persistence.Configuration;

namespace Suppliers.API.Shared.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ServiceDbContext _context;

    public UnitOfWork(ServiceDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}