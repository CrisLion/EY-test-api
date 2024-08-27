using AutoMapper;
using Suppliers.API.Security.Domain.Models.Aggregates;
using Suppliers.API.Security.Domain.Models.Commands;

namespace Suppliers.API.Security.Application.Mapping;

public class RequestToModel : Profile
{
    public RequestToModel()
    {
        CreateMap<RegisterUserCommand, User>();
    }
}