using Clean.Domain.Common.Entities;
using Clean.Domain.Entities.Customers;
using Clean.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clean.Persistence.Sql.DbContext;

public class ApplicationDbContext(DbContextOptions options) : IdentityDbContext<User, Role, Guid>(options)
{
    public DbSet<Customer> Customers { get; set; }

    public override int SaveChanges()
    {
        ValidateAllEntities();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ValidateAllEntities();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void ValidateAllEntities()
    {
        var entities = ChangeTracker.Entries()
            .Where(e => e.Entity is IValidatableEntity &&
                        (e.State == EntityState.Added || e.State == EntityState.Modified))
            .Select(e => (IValidatableEntity)e.Entity);

        foreach (var entity in entities)
            entity.ValidateInvariants();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(GetType().Assembly,
            x => x.Namespace != null && x.Namespace.StartsWith("Clean.Persistence.Sql"));
        base.OnModelCreating(builder);
    }

}
