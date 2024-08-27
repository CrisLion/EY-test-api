using AutoMapper;
using Suppliers.API.Security.Domain.Models.Aggregates;
using Suppliers.API.Security.Domain.Models.Responses;

namespace Suppliers.API.Security.Application.Mapping;

public class ModelToResponse : Profile
{
    public ModelToResponse()
    {
        CreateMap<User, UserResponse>();
    }
}