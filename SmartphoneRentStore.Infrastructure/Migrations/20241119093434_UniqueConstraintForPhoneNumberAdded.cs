using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartphoneRentStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UniqueConstraintForPhoneNumberAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0fd2f7a9-fe03-4247-a65f-bf9cf11902cb", "AQAAAAIAAYagAAAAEO4Wv+UYaHYh5zbYStmUoJ08WxA7TuD9SNJo4UmCpkaEvn0+u7tlRXsSvyqDM59Yog==", "9165dccf-3955-4a4d-9699-c6b1ea8c6cd2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2dfa330c-793e-41dd-8320-238b2b986e29", "AQAAAAIAAYagAAAAEC0yBKVpl13T24a3zYTkjoQ1Mw/z2iEFRoU9GvHiJeZdQ0nzDXm/148VJ3G7v7biuw==", "b4d7ba24-7573-4609-a0b9-a72d6342526b" });

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_PhoneNumber",
                table: "Suppliers",
                column: "PhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Suppliers_PhoneNumber",
                table: "Suppliers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a71dbeb-d6ba-4da6-a63f-8fcec7ea89c7", "AQAAAAIAAYagAAAAENVNOpvDB3g4y2gZK2sO/tESe9+RG91Qtmp/WX7PAYS4D2FQlh87q4/iPz58NWfTGA==", "5d8b94ca-c0f1-4c54-9cd4-410131e0ac6c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a63b05b-09e5-4dc9-acaa-0a6d49f54812", "AQAAAAIAAYagAAAAEFPdWVzGVcIfnSvNIhKj35YSCbZtKWV0KCyy6H/olK9rXo2hayod/zkIvBRwBw+evg==", "bbbf111d-dca2-4254-81ac-b91680fda46f" });
        }
    }
}
