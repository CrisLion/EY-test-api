using Microsoft.EntityFrameworkCore;
using Suppliers.API.Shared.Domain.Repositories;
using Suppliers.API.Shared.Infrastructure.Persistence.Configuration;
using Suppliers.API.Shared.Infrastructure.Persistence.Repositories;

namespace Suppliers.API.Shared;

public static class SharedServiceRegistration
{
    public static IServiceCollection AddSharedService(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ServiceConnection");

        services.AddDbContext<ServiceDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
      
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAllPolicy",
                policy => policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        return services;
    }
}