using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartphoneRentStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserClaimsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "user:fullname", "Supplier Supplierer", "dea12856-c198-4129-b3f3-b893d8395082" },
                    { 2, "user:fullname", "Buyer Buyerer", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" },
                    { 3, "user:fullname", "Great Admin", "0827ba07-dee3-4244-b882-e4113dcee101" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0827ba07-dee3-4244-b882-e4113dcee101",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01e5a36e-3ac6-4146-9dc5-f90ee0f615bb", "AQAAAAIAAYagAAAAEFNATJDoj3ElF79DPgV06aUOObHqc1RRH8CNAB8Qyve8L2y/vVIn+fwjt1h5uK31RA==", "bc0cefe1-f43f-48f6-80c2-d30fbc3097c8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64a45345-232b-45af-ba2d-59f0e621a69d", "AQAAAAIAAYagAAAAEAmRsJjJac50zNFPakqZWowZZ9oFf7VZy1vtdnDfvYpvcQcpwfxInyajlK70ckwIRw==", "e8a14b85-a992-4fef-8e5d-a6140564fda0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3125c006-2c76-41f4-9e09-7d429eed51fd", "AQAAAAIAAYagAAAAEP0QCbMeXhwtu8oq47B+CFfiu2Dezy2qOxEoKwdkXbAzz2uGHlnBCFyehf2m+PpvuQ==", "d8ce8bcf-0586-4e0a-a8ad-2e83f3b7909a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0827ba07-dee3-4244-b882-e4113dcee101",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e322a9a6-e2b2-4480-994e-2a220804c869", "AQAAAAIAAYagAAAAELN36qHY6PjVwVYpvQAyDhpTv9HjEVQfhyiOK6GUjKn0/wkSxPiUNqMSKUZrnstS+Q==", "58d8220a-6498-4039-9263-715a6f1928f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65e169f6-baa3-4335-ba59-c07d432a57ad", "AQAAAAIAAYagAAAAEJ2qytxIyG/gM8vB/wQ9AUezKjO+1z7wMInY/1EUT20lOMuAhY9Vie4komq0yIpTzw==", "4cd4b01b-20cb-441d-9d4c-f2e6db8f64df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16918155-8243-41e4-b328-a7b9290bb715", "AQAAAAIAAYagAAAAENGYzvb4Zd2lv5NZ4bQhgGwHQ38uquN7tSDjdV5YjP0kKUJK/LZoR38alLwxAO+kBA==", "3dd27afb-707f-44b3-93b1-625b3f254d43" });
        }
    }
}
