namespace SmartphoneRentStore.Infrastructure.Data.SeedDb
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SmartphoneRentStore.Infrastructure.Data.Models;


    internal class SmartPhoneConfiguration : IEntityTypeConfiguration<SmartPhone>
    {
        public void Configure(EntityTypeBuilder<SmartPhone> builder)
        {
            builder.HasOne(h => h.Category)
                   .WithMany(c => c.SmartPhones)
                   .HasForeignKey(s => s.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(h => h.Supplier)
                   .WithMany(c => c.SmartPhones)
                   .HasForeignKey(s => s.SupplierId)
                   .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new SmartPhone[] { data.FirstSmartPhone, data.SecondSmartPhone, data.ThirdSmartPhone });
        }
    }
}
