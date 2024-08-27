using Suppliers.API.DueDiligence.Domain.Models.Aggregate;
using Suppliers.API.Shared.Domain.Models.Entities;

namespace Suppliers.API.Security.Domain.Models.Aggregates;

public class User : BaseDomainModel
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public ICollection<Supplier>? Suppliers { get; set; }
}