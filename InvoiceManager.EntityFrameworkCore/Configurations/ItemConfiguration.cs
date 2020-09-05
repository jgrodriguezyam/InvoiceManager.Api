using InvoiceManager.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceManager.EntityFrameworkCore.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.Property(p => p.Number).IsRequired();
            builder.Property(p => p.Hours).HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(p => p.Rate).HasColumnType("money").IsRequired();
            builder.Property(p => p.Amount).HasColumnType("money").IsRequired();
            builder.Property(p => p.InvoiceId).IsRequired();
            builder.HasOne(p => p.Invoice).WithMany(p => p.Items);

            builder.Property(p => p.CreatedBy).IsRequired();
            builder.Property(p => p.CreatedOn).IsRequired();
            builder.Property(p => p.ModifiedBy).IsRequired();
            builder.Property(p => p.ModifiedOn).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
        }
    }
}
