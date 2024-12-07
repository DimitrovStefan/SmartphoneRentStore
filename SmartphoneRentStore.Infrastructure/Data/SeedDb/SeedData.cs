namespace SmartphoneRentStore.Infrastructure.Data.SeedDb
{
    using Microsoft.AspNetCore.Identity;
    using SmartphoneRentStore.Infrastructure.Data.Models;

    internal class SeedData
    {
        public ApplicationUser SupplierUser { get; set; }
        public ApplicationUser BuyerUser { get; set; }

        public ApplicationUser AdminUser { get; set; }

        public Supplier AdminSupplier { get; set; }
        public Supplier Supplier { get; set; }

        public Category LowCategory { get; set; }
        public Category MediumCategory { get; set; }
        public Category HighCategory { get; set; }


        public SmartPhone FirstSmartPhone { get; set; }
        public SmartPhone SecondSmartPhone { get; set; }
        public SmartPhone ThirdSmartPhone { get; set; }

        public SeedData()
        {
            SeedUsers();
            SeedSuppliers();
            SeedCategories();
            SeedSmartPhones();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            SupplierUser = new ApplicationUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "supplier@mail.com",
                NormalizedUserName = "supplier@mail.com",
                Email = "supplier@mail.com",
                NormalizedEmail = "supplier@mail.com",
                FirstName = "Supplier",
                LastName = "Supplierer"
            };

            SupplierUser.PasswordHash =
                 hasher.HashPassword(SupplierUser, "supplier123");

            BuyerUser = new ApplicationUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "buyer@mail.com",
                NormalizedUserName = "buyer@mail.com",
                Email = "buyer@mail.com",
                NormalizedEmail = "buyer@mail.com",
                FirstName = "Buyer",
                LastName = "Buyerer"
            };

            BuyerUser.PasswordHash =
            hasher.HashPassword(SupplierUser, "buyer123");

            AdminUser = new ApplicationUser()
            {
                Id = "0827ba07-dee3-4244-b882-e4113dcee101",
                UserName = "admin@mail.com",
                NormalizedUserName = "ADMIN@MAIL.COM",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM",
                FirstName = "Great",
                LastName = "Admin"
            };

            AdminUser.PasswordHash = 
            hasher.HashPassword(AdminUser, "admin123");
        }

        private void SeedSuppliers()
        {
            Supplier = new Supplier()
            {
                Id = 1,
                PhoneNumber = "+359555555555",
                City = "Burgas",
                UserId = SupplierUser.Id
            };

            AdminSupplier = new Supplier()
            {
                Id = 3,
                PhoneNumber = "+359555555556",
                City = "Burgas",
                UserId = AdminUser.Id
            };
        }

        private void SeedCategories()
        {
            LowCategory = new Category()
            {
                Id = 1,
                Name = "Low"
            };

            MediumCategory = new Category()
            {
                Id = 2,
                Name = "Medium"
            };

            HighCategory = new Category()
            {
                Id = 3,
                Name = "High"
            };
        }

        private void SeedSmartPhones()
        {
            FirstSmartPhone = new SmartPhone()
            {
                Id = 1,
                Title = "Samsung S24 Ultra",
                Description = "The Samsung Galaxy S24 Ultra comes with 6.8-inch Dynamic AMOLED display with 120Hz refresh rate and Qualcomm Snapdragon 8 Gen 3 processor. Specs also include 5000mAh battery and Quad camera setup on the back.",
                ImageUrl = "https://img.swipe.bg/phones/medium/samsung-galaxy-s24-ultra.jpg",
                PricePerMonth = 350.00M,
                CategoryId = HighCategory.Id,
                SupplierId = Supplier.Id,
                RenterId = BuyerUser.Id
            };

            SecondSmartPhone = new SmartPhone()
            {
                Id = 2,
                Title = "Iphone 16 Pro Max",
                Description = "The iPhone 16 Pro Mx comes with 6.9-icnh OLED display with 120Hz refresh rate and Apple's A18 Pro processor. Specs also include Triple camera setup on the back and better battery life than the previous model.",
                ImageUrl = "https://s13emagst.akamaized.net/products/76828/76827268/images/res_2e96db7aae423d09717a344bb22a43d2.jpg",
                PricePerMonth = 400.00M,
                CategoryId = HighCategory.Id,
                SupplierId = Supplier.Id,
                RenterId = BuyerUser.Id
            };

            ThirdSmartPhone = new SmartPhone()
            {
                Id = 3,
                Title = "Huawei Nova",
                Description = "Huawei nova sports a 5-inch full HD display and a single 12MP rear camera with f2/2 aperture and 1.25 micron pixels. There's also an 8-megapixel selfie camera in the front that features f/2.0 aperture. The Chinese company has decided to go with a 2GHz octa-core",
                ImageUrl = "https://www.mrejata.bg/image/cache/data/2016/Smartphone/Huawei/6901443143689/Huawei_Nova_DUAL_SIM_CAN-L11_6901443143689_3-500x500.jpg",
                PricePerMonth = 100.00M,
                CategoryId = LowCategory.Id,
                SupplierId = Supplier.Id,
                RenterId = BuyerUser.Id
            };
        }

    }
}
