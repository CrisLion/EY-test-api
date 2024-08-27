using Microsoft.EntityFrameworkCore;
using Suppliers.API.DueDiligence.Domain.Models.Aggregate;
using Suppliers.API.Security.Domain.Models.Aggregates;
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
        builder.Entity<Supplier>().HasOne(s => s.User).WithMany(u => u.Suppliers).HasForeignKey(s => s.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<User>().Property(s => s.Id).ValueGeneratedOnAdd();
        builder.Entity<User>().Property(s => s.Username).IsRequired().HasMaxLength(30);
        builder.Entity<User>().Property(s => s.Password).IsRequired().HasMaxLength(120);
        builder.Entity<User>().HasMany(s => s.Suppliers).WithOne(s => s.User).HasForeignKey(s => s.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
    }
    
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<User> Users { get; set; }
}