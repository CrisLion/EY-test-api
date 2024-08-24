using Microsoft.EntityFrameworkCore;
using Suppliers.API.DueDiligence.Domain.Models.Aggregate;
using Suppliers.API.Shared.Domain.Models.Entities;

namespace Suppliers.API.Shared.Infrastructure.Persistence.Configuration;

public class ServiceDbContext : DbContext
{
    public ServiceDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedAt = DateTime.Now;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Supplier>().Property(s => s.Id).ValueGeneratedOnAdd();
        builder.Entity<Supplier>().Property(s => s.CompanyName).IsRequired().HasMaxLength(100);
        builder.Entity<Supplier>().Property(s => s.BrandName).IsRequired().HasMaxLength(100);
        builder.Entity<Supplier>().Property(s => s.TaxIdentification).IsRequired();
        builder.Entity<Supplier>().Property(s => s.TelephoneNumber).IsRequired();
        builder.Entity<Supplier>().Property(s => s.Email).IsRequired();
        builder.Entity<Supplier>().Property(s => s.Website).IsRequired();
        builder.Entity<Supplier>().Property(s => s.Country).IsRequired();
        builder.Entity<Supplier>().Property(s => s.AnnualBillingInDollars).IsRequired();
    }
    
    public DbSet<Supplier> Suppliers { get; set; }
}