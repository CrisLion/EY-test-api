using Microsoft.AspNetCore.Authentication.JwtBearer;
using Suppliers.API.DueDiligence.Application.Mapping;
using Suppliers.API.Security.Application.Features;
using Suppliers.API.Security.Domain.Repositories;
using Suppliers.API.Security.Domain.Services;
using Suppliers.API.Security.Infrastructure.Persistence.Repositories;

namespace Suppliers.API.Security;

public static class SecurityRegistration
{
    public static IServiceCollection AddSecurityServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        
        services.AddAutoMapper(
            typeof(RequestToModel),
            typeof(ModelToResponse)
        );

        services.AddScoped<IEncryptService, EncryptService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserCommandService, UserCommandService>();
        services.AddScoped<IUserQueryService, UserQueryService>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
        
        return services;
    }
}