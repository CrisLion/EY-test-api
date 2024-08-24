using Suppliers.API.DueDiligence.Domain.Models.Commands;
using Suppliers.API.DueDiligence.Domain.Models.Responses;

namespace Suppliers.API.DueDiligence.Domain.Services;

public interface ISupplierCommandService
{
    Task<SupplierResponse> Handle(CreateSupplierCommand command);
    Task<SupplierResponse> Handle(int id, UpdateSupplierCommand command);
    Task<bool> Handle(DeleteSupplierCommand command);
}