using System.ComponentModel.DataAnnotations;

namespace Suppliers.API.DueDiligence.Domain.Models.Commands;

public record DeleteSupplierCommand(
    [Required] int Id
);