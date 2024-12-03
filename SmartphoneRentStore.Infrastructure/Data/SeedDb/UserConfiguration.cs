namespace SmartphoneRentStore.Infrastructure.Data.SeedDb
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SmartphoneRentStore.Infrastructure.Data.Models;

    internal class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var data = new SeedData();

            builder.HasData(new ApplicationUser[] { data.SupplierUser, data.BuyerUser });
        }
    }
}
