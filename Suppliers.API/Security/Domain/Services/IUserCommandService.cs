using Suppliers.API.Security.Domain.Models.Commands;
using Suppliers.API.Security.Domain.Models.Responses;

namespace Suppliers.API.Security.Domain.Services;

public interface IUserCommandService
{
    Task<string> Handle(LoginUserCommand command);
    Task<UserResponse> Handle(RegisterUserCommand command);
    Task<UserResponse> Handle(int id, UpdateUserCommand command);
    Task<bool> Handle(DeleteUserCommand command);
}