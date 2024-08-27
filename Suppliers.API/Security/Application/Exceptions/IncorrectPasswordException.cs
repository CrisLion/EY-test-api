using Suppliers.API.Shared.Application.Exceptions;

namespace Suppliers.API.Security.Application.Exceptions;

public class IncorrectPasswordException : ValidationException
{
    public IncorrectPasswordException() : base("Incorrect password")
    {
    }
}