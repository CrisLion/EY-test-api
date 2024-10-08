﻿using System.ComponentModel.DataAnnotations;

namespace Suppliers.API.Security.Domain.Models.Commands;

public record RegisterUserCommand(
    [Required] [MinLength(1, ErrorMessage = "CompanyName cannot be empty")] string Username,
    [Required] [MinLength(1, ErrorMessage = "CompanyName cannot be empty")] string Password
);