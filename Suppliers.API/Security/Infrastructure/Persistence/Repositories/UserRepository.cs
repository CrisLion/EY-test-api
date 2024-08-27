using Microsoft.EntityFrameworkCore;
using Suppliers.API.Security.Domain.Models.Aggregates;
using Suppliers.API.Security.Domain.Repositories;
using Suppliers.API.Shared.Infrastructure.Persistence.Configuration;
using Suppliers.API.Shared.Infrastructure.Persistence.Repositories;

namespace Suppliers.API.Security.Infrastructure.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(ServiceDbContext context) : base(context)
    {
    }
    
    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        return await Context.Users
            .Where(user => user.Username == username)
            .FirstOrDefaultAsync();
    }
}