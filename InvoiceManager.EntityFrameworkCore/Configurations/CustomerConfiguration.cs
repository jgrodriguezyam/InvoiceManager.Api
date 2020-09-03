using InvoiceManager.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceManager.EntityFrameworkCore.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.LastName).IsRequired();
            builder.Property(p => p.Gender).IsRequired();
            builder.Property(p => p.CreatedBy).IsRequired();
            builder.Property(p => p.CreatedOn).IsRequired();
            builder.Property(p => p.ModifiedBy).IsRequired();
            builder.Property(p => p.ModifiedOn).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
        }
    }
}
