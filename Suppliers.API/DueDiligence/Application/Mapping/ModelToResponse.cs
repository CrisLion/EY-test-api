using AutoMapper;
using Suppliers.API.DueDiligence.Domain.Models.Aggregate;
using Suppliers.API.DueDiligence.Domain.Models.Responses;

namespace Suppliers.API.DueDiligence.Application.Mapping;

public class ModelToResponse : Profile
{
    public ModelToResponse()
    {
        CreateMap<Supplier, SupplierResponse>();
    }
}