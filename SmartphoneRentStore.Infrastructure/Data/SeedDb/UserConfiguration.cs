namespace SmartphoneRentStore.Infrastructure.Data.SeedDb
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class UserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            var data = new SeedData();

            builder.HasData(new IdentityUser[] { data.SupplierUser, data.BuyerUser });
        }
    }
}
