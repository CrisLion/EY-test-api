using Suppliers.API.Security.Domain.Models.Aggregates;
using Suppliers.API.Shared.Domain.Repositories;

namespace Suppliers.API.Security.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetUserByUsernameAsync(string username);
}