using Clean.Domain.Entities.Customers;
using Clean.Domain.Entities.Customers.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Persistence.Sql.Customers;

public class CustomerConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        //Id
        builder.HasKey(c => c.Id);

        //FirstName
        builder.Property(c => c.FirstName).HasConversion(c => c.Value, c => new CustomerFirstName(c));
        builder.Property(c => c.FirstName).HasMaxLength(50).IsRequired();

        //LastName
        builder.Property(c => c.LastName).HasConversion(c => c.Value, c => new CustomerLastName(c));
        builder.Property(c => c.LastName).HasMaxLength(50).IsRequired();

        //Mobile
        builder.Property(c => c.Mobile).HasConversion(c => c.Value, c => new CustomerMobile(c));
        builder.Property(c => c.Mobile).HasMaxLength(11).IsRequired();

        //NationalCode
        builder.Property(c => c.NationalCode).HasConversion(c => c.Value, c => new CustomerNationalCode(c));
        builder.Property(c => c.NationalCode).HasMaxLength(10).IsRequired();


        //InsertOn
        builder.Property(c => c.InsertOn).HasColumnType("datetime").IsRequired();
        //UpdateOn
        builder.Property(c => c.UpdateOn).HasColumnType("datetime").IsRequired();
        //RowVersion
        builder.Property(c => c.RowVersion).IsRowVersion().IsRequired();
    }
}
