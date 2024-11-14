namespace SmartphoneRentStore.Infrastructure.Data.SeedDb
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SmartphoneRentStore.Infrastructure.Data.Models;


    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            var data = new SeedData();

            builder.HasData(new Category[] { data.LowCategory, data.MediumCategory, data.HighCategory });
        }
    }
}
