using Microsoft.OpenApi.Models;
using Suppliers.API.DueDiligence;
using Suppliers.API.Security;
using Suppliers.API.Security.Interfaces.REST.Middleware;
using Suppliers.API.Shared;
using Suppliers.API.Shared.Infrastructure.Persistence.Configuration;
using Suppliers.API.Shared.Interfaces.REST.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddSharedService(builder.Configuration);
builder.Services.AddDueDiligenceServices();
builder.Services.AddSecurityServices();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
await using (var context = scope.ServiceProvider.GetService<ServiceDbContext>())
{
    context!.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthorization();

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseMiddleware<AuthenticationMiddleware>();

app.MapControllers();

app.Run();