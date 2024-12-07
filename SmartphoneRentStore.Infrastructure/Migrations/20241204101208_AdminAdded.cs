using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartphoneRentStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdminAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0355e7f-586a-4daf-83a2-36b48870aa04", "Buyer", "Buyerer", "AQAAAAIAAYagAAAAEDeK3Rpbq9SOiOTbC6wFVsAR4MKtvs9Vv58Xs71QkoXSuCcXcDv6XMSlWGDkT2yeOw==", "7dbc11ab-47c7-4bbf-b166-7b02240adf2b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ab0c686-662f-47d9-9fd7-7c2b936f3579", "Supplier", "Supplierer", "AQAAAAIAAYagAAAAEN8sCOJsSLWPyYRO9yAqYLnEVmVIP1MjZEDwBVNUNolvZoTZN0c7M+QnyGF8iyYSIQ==", "b34a23e4-d85a-411e-87a1-1af4cce41710" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0827ba07-dee3-4244-b882-e4113dcee101", 0, "43e04a14-9e00-43ed-847f-0db85c7eae02", "admin@mail.com", false, "Great", "Admin", false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAIAAYagAAAAEO5mxFSEAfysExUtsrvix4fbBFAfoWahpBYxi6xdkwI9pkAptW3r9NvE9JbXGkPUbQ==", null, false, "b4881871-42ee-43b5-ae70-2d1fbbd1db33", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "City", "PhoneNumber", "UserId" },
                values: new object[] { 3, "Burgas", "+359555555556", "0827ba07-dee3-4244-b882-e4113dcee101" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0827ba07-dee3-4244-b882-e4113dcee101");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b76469f-6d68-42a8-8204-3861763a58e6", "", "", "AQAAAAIAAYagAAAAEKzwu0jCbYV1AW7kNPBsBFI4+I3wniJFD3FBID+eychbswn7DgMF8WUVxqZKys7kmA==", "15c6a813-5b83-458c-a39a-528baff26768" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79240092-92be-4eba-b2e8-eb2ec80d97b0", "", "", "AQAAAAIAAYagAAAAEFUekDRIA+NxKpiL5pENzfCO+caKC0mVWzBMXt6Hzu5kzhSV9aIj+KX9Dmyx69LyHQ==", "c4a520ce-2d0d-4b21-ba6c-d9802f96dd0f" });
        }
    }
}
