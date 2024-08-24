namespace Suppliers.API.DueDiligence.Domain.Models.Responses;

public record SupplierResponse(
    int Id,
    string BrandName,
    long TaxIdentification,
    string TelephoneNumber,
    string Email,
    string Website,
    string Country,
    double AnnualBillingInDollars
);