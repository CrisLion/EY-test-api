using Suppliers.API.DueDiligence.Application.Features;
using Suppliers.API.DueDiligence.Application.Mapping;
using Suppliers.API.DueDiligence.Domain.Repositories;
using Suppliers.API.DueDiligence.Domain.Services;
using Suppliers.API.DueDiligence.Infrastructure.Persistence.Repositories;

namespace Suppliers.API.DueDiligence;

public static class DueDiligenceRegistration
{
    public static IServiceCollection AddDueDiligenceServices(this IServiceCollection services)
    {
        services.AddScoped<ISupplierRepository, SupplierRepository>();
        
        services.AddAutoMapper(
            typeof(RequestToModel),
            typeof(ModelToResponse)
        );

        services.AddScoped<ISupplierCommandService, SupplierCommandService>();
        services.AddScoped<ISupplierQueryService, SupplierQueryService>();
        
        return services;
    }
}