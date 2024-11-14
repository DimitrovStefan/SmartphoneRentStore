using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartphoneRentStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Renterid",
                table: "SmartPhones",
                newName: "RenterId");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "3a71dbeb-d6ba-4da6-a63f-8fcec7ea89c7", "buyer@mail.com", false, false, null, "buyer@mail.com", "buyer@mail.com", "AQAAAAIAAYagAAAAENVNOpvDB3g4y2gZK2sO/tESe9+RG91Qtmp/WX7PAYS4D2FQlh87q4/iPz58NWfTGA==", null, false, "5d8b94ca-c0f1-4c54-9cd4-410131e0ac6c", false, "buyer@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "6a63b05b-09e5-4dc9-acaa-0a6d49f54812", "supplier@mail.com", false, false, null, "supplier@mail.com", "supplier@mail.com", "AQAAAAIAAYagAAAAEFPdWVzGVcIfnSvNIhKj35YSCbZtKWV0KCyy6H/olK9rXo2hayod/zkIvBRwBw+evg==", null, false, "bbbf111d-dca2-4254-81ac-b91680fda46f", false, "supplier@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Low" },
                    { 2, "Medium" },
                    { 3, "High" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "City", "PhoneNumber", "UserId" },
                values: new object[] { 1, "Burgas", "+359555555555", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "SmartPhones",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "SupplierId", "Title" },
                values: new object[,]
                {
                    { 1, 3, "The Samsung Galaxy S24 Ultra comes with 6.8-inch Dynamic AMOLED display with 120Hz refresh rate and Qualcomm Snapdragon 8 Gen 3 processor. Specs also include 5000mAh battery and Quad camera setup on the back.", "https://img.swipe.bg/phones/medium/samsung-galaxy-s24-ultra.jpg", 350.00m, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 1, "Samsung S24 Ultra" },
                    { 2, 3, "The iPhone 16 Pro Mx comes with 6.9-icnh OLED display with 120Hz refresh rate and Apple's A18 Pro processor. Specs also include Triple camera setup on the back and better battery life than the previous model.", "https://s13emagst.akamaized.net/products/76828/76827268/images/res_2e96db7aae423d09717a344bb22a43d2.jpg", 400.00m, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 1, "Iphone 16 Pro Max" },
                    { 3, 1, "Huawei nova sports a 5-inch full HD display and a single 12MP rear camera with f2/2 aperture and 1.25 micron pixels. There's also an 8-megapixel selfie camera in the front that features f/2.0 aperture. The Chinese company has decided to go with a 2GHz octa-core", "https://www.mrejata.bg/image/cache/data/2016/Smartphone/Huawei/6901443143689/Huawei_Nova_DUAL_SIM_CAN-L11_6901443143689_3-500x500.jpg", 100.00m, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 1, "Huawei Nova" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SmartPhones",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SmartPhones",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SmartPhones",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.RenameColumn(
                name: "RenterId",
                table: "SmartPhones",
                newName: "Renterid");
        }
    }
}
