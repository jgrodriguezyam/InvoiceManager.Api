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
            builder.HasOne(p => p.Company).WithMany(p => p.Invoices).HasForeignKey(p => p.CompanyId);
            builder.HasOne(p => p.Customer).WithMany(p => p.Invoices).HasForeignKey(p => p.CustomerId);
            builder.HasMany(p => p.Items).WithOne(p => p.Invoice).HasForeignKey(p => p.InvoiceId);

            builder.Property(p => p.CreatedBy).IsRequired();
            builder.Property(p => p.CreatedOn).IsRequired();
            builder.Property(p => p.ModifiedBy).IsRequired();
            builder.Property(p => p.ModifiedOn).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
        }
    }
}
