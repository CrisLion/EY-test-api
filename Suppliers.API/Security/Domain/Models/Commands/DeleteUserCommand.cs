using System.ComponentModel.DataAnnotations;

namespace Suppliers.API.Security.Domain.Models.Commands;

public record DeleteUserCommand(
    [Required] int Id
);