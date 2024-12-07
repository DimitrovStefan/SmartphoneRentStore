namespace SmartphoneRentStore.Infrastructure.Data.SeedDb
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SmartphoneRentStore.Infrastructure.Data.Models;

    internal class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            var data = new SeedData();

            builder.HasData(new Supplier[] { data.Supplier, data.AdminSupplier });
        }
    }
}
