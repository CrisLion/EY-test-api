using Microsoft.EntityFrameworkCore;
using Suppliers.API.DueDiligence.Domain.Models.Aggregate;
using Suppliers.API.DueDiligence.Domain.Repositories;
using Suppliers.API.Shared.Infrastructure.Persistence.Configuration;
using Suppliers.API.Shared.Infrastructure.Persistence.Repositories;

namespace Suppliers.API.DueDiligence.Infrastructure.Persistence.Repositories;

public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
{
    public SupplierRepository(ServiceDbContext context) : base(context)
    {
    }

    public async Task<IReadOnlyCollection<Supplier>> GetSuppliersByUserId(int userId)
    {
        return await Context.Suppliers.Where(s => s.UserId == userId).ToListAsync();
    }
}