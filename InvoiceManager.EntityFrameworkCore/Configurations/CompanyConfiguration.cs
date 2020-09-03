using InvoiceManager.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceManager.EntityFrameworkCore.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Address).IsRequired();
            builder.Property(p => p.City).IsRequired();
            builder.Property(p => p.CreatedBy).IsRequired();
            builder.Property(p => p.CreatedOn).IsRequired();
            builder.Property(p => p.ModifiedBy).IsRequired();
            builder.Property(p => p.ModifiedOn).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
        }
    }
}
