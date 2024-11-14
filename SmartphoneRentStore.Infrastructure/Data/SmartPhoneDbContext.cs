using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartphoneRentStore.Infrastructure.Data.Models;
using SmartphoneRentStore.Infrastructure.Data.SeedDb;

namespace SmartphoneRentStore.Infastructure.Data
{
    public class SmartPhoneDbContext : IdentityDbContext
    {
        public SmartPhoneDbContext(DbContextOptions<SmartPhoneDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new SupplierConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new SmartPhoneConfiguration());


            base.OnModelCreating(builder);
        }

        DbSet<Supplier> Suppliers { get; set; } = null!;
        DbSet<SmartPhone> SmartPhones { get; set; } = null!;
        DbSet<Category> Categories { get; set; } = null!;
    }
}
