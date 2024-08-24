using Suppliers.API.DueDiligence.Domain.Models.Aggregate;
using Suppliers.API.DueDiligence.Domain.Models.Queries;
using Suppliers.API.DueDiligence.Domain.Models.Responses;

namespace Suppliers.API.DueDiligence.Domain.Services;

public interface ISupplierQueryService
{
    Task<SupplierResponse> Handle(GetSupplierByIdQuery query);
    Task<IReadOnlyCollection<SupplierResponse>> Handle(GetSuppliersQuery query);
}