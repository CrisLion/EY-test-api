using Suppliers.API.Security.Domain.Models.Queries;
using Suppliers.API.Security.Domain.Models.Responses;

namespace Suppliers.API.Security.Domain.Services;

public interface IUserQueryService
{
    Task<IReadOnlyCollection<UserResponse>> Handle(GetUsersQuery query);
    Task<UserResponse?> Handle(GetUserByIdQuery query);
}