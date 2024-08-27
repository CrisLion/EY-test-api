using Suppliers.API.Security.Domain.Models.Aggregates;
using Suppliers.API.Shared.Domain.Models.Entities;

namespace Suppliers.API.DueDiligence.Domain.Models.Aggregate;

public class Supplier : BaseDomainModel
{
    public required string CompanyName { get; set; }
    public required string BrandName { get; set; }
    public required long TaxIdentification { get; set; }
    public required string TelephoneNumber { get; set; }
    public required string Email { get; set; }
    public required string Website { get; set; }
    public required string Country { get; set; }
    public required double AnnualBillingInDollars { get; set; }
    public required int UserId { get; set; }
    public User User { get; set; }
}