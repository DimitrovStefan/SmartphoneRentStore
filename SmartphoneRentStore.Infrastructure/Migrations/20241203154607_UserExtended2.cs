using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartphoneRentStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserExtended2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3594897c-908b-4fc7-946f-441534d68beb", "AQAAAAIAAYagAAAAEEjdcqqe7DgAydrLF0LJ0Wh+Kmn++Sktf0ucZhBsg/kSrfZm5SercsWidI9KUUqkWw==", "5fcfdb87-4200-4e73-ab42-f9f54607f078" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f69a030-e62b-4eb4-b100-e0d257a8072c", "AQAAAAIAAYagAAAAEDv8JdwKmX8aKMw6SmVFtMPuqMrXpggobKVryNPlqn05xGsvDEFI7elVSbKYSGJRyQ==", "945b25eb-c0f2-491b-83e9-ca36c431ab82" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40914e3b-0ec6-4be6-a155-3b1b364fbcdb", "AQAAAAIAAYagAAAAEA0/qnJLDEjD7lnbY/dHLXa1r9nKs1gZwu1M3/kbq0WHPE8mGAUyter1nHYUIQCl/A==", "3dd96470-7d59-4685-8824-835a839e0c3b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3f1a58b-6639-4fe8-a613-485fb2024398", "AQAAAAIAAYagAAAAEH9AxZBjibf69JFnr8LeagyNlyydAauTMvLwpLGOYpAdGhwhz5tz51J88P/jVGhXgg==", "ebf7e3b6-bb5f-4014-883d-6eb92532d659" });
        }
    }
}
