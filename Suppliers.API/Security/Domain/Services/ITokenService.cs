using Suppliers.API.Security.Domain.Models.Aggregates;

namespace Suppliers.API.Security.Domain.Services;

public interface ITokenService
{
    string GenerateToken(User user);
    Task<int?> ValidateToken(string token);
}