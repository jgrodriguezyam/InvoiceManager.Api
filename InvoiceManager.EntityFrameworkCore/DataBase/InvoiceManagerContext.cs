using InvoiceManager.EntityFrameworkCore.Configurations;
using InvoiceManager.Model;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManager.EntityFrameworkCore.DataBase
{
    public class InvoiceManagerContext : DbContext
    {
        public InvoiceManagerContext(DbContextOptions<InvoiceManagerContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        }
    }
}
