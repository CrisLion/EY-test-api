using Suppliers.API.Shared.Application.Exceptions;

namespace Suppliers.API.Security.Application.Exceptions;

public class DuplicatedUserUsernameException : DuplicatedEntityAttributeException
{
    public DuplicatedUserUsernameException(object attributeValue) 
        : base("User", "Username", attributeValue)
    {
    }
}