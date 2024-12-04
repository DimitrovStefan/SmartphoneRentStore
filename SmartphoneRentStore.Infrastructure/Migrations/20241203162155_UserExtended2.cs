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
                values: new object[] { "2b76469f-6d68-42a8-8204-3861763a58e6", "AQAAAAIAAYagAAAAEKzwu0jCbYV1AW7kNPBsBFI4+I3wniJFD3FBID+eychbswn7DgMF8WUVxqZKys7kmA==", "15c6a813-5b83-458c-a39a-528baff26768" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79240092-92be-4eba-b2e8-eb2ec80d97b0", "AQAAAAIAAYagAAAAEFUekDRIA+NxKpiL5pENzfCO+caKC0mVWzBMXt6Hzu5kzhSV9aIj+KX9Dmyx69LyHQ==", "c4a520ce-2d0d-4b21-ba6c-d9802f96dd0f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
