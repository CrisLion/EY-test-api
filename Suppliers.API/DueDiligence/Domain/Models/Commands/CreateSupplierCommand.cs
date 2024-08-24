using System.ComponentModel.DataAnnotations;

namespace Suppliers.API.DueDiligence.Domain.Models.Commands;

public record CreateSupplierCommand(
    [Required] [MinLength(1, ErrorMessage = "CompanyName cannot be empty")] string CompanyName,
    [Required] [MinLength(1, ErrorMessage = "CompanyName cannot be empty")] string BrandName,
    [Required] [Range(10000000000, 99999999999, ErrorMessage = "Tax identification must be between 10000000000 and 99999999999")] long TaxIdentification,
    [Required] [Phone(ErrorMessage = "Invalid telephoneNumber")] string TelephoneNumber,
    [Required] [EmailAddress(ErrorMessage = "Invalid email address")] string Email,
    [Required] [Url(ErrorMessage = "Invalid website")] string Website,
    [Required] [MinLength(1, ErrorMessage = "Country cannot be empty")] string Country,
    [Required] [Range(0, 99999999.99, ErrorMessage = "Annual billing in dollars must be between 0 and 99999999.99")] double AnnualBillingInDollars
);