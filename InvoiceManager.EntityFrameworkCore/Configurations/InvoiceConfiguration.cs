using InvoiceManager.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceManager.EntityFrameworkCore.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(p => p.PurchaseOrderNumber).IsRequired();
            builder.Property(p => p.CompanyId).IsRequired();
            builder.Property(p => p.CustomerId).IsRequired();
            builder.HasMany(p => p.Items).WithOne(p => p.Invoice);

            builder.Property(p => p.CreatedBy).IsRequired();
            builder.Property(p => p.CreatedOn).IsRequired();
            builder.Property(p => p.ModifiedBy).IsRequired();
            builder.Property(p => p.ModifiedOn).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
        }
    }
}
