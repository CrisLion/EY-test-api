using AutoMapper;
using Suppliers.API.DueDiligence.Domain.Models.Aggregate;
using Suppliers.API.DueDiligence.Domain.Models.Commands;

namespace Suppliers.API.DueDiligence.Application.Mapping;

public class RequestToModel : Profile
{
    public RequestToModel()
    {
        CreateMap<CreateSupplierCommand, Supplier>();
        CreateMap<UpdateSupplierCommand, Supplier>();
    }
}