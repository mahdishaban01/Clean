using Clean.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Persistence.Sql.Roles;

public class RoleConfig : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder
            .HasOne(r => r.InsertUser)
            .WithMany()
            .HasForeignKey(r => r.InsertUserId)
            .OnDelete(DeleteBehavior.Restrict); 

        builder
            .HasOne(r => r.UpdateUser)
            .WithMany()
            .HasForeignKey(r => r.UpdateUserId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
