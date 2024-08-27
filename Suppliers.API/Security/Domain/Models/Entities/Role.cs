using Suppliers.API.Security.Domain.Models.Aggregates;
using Suppliers.API.Shared.Domain.Models.Entities;

namespace Suppliers.API.Security.Domain.Models.Entities;

public class Role : BaseDomainModel
{
    public required string Name { get; set; }
    public required ICollection<User> Users { get; set; }
}