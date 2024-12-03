using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartphoneRentStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserExtended : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "SmartPhones");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40914e3b-0ec6-4be6-a155-3b1b364fbcdb", "", "", "AQAAAAIAAYagAAAAEA0/qnJLDEjD7lnbY/dHLXa1r9nKs1gZwu1M3/kbq0WHPE8mGAUyter1nHYUIQCl/A==", "3dd96470-7d59-4685-8824-835a839e0c3b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3f1a58b-6639-4fe8-a613-485fb2024398", "", "", "AQAAAAIAAYagAAAAEH9AxZBjibf69JFnr8LeagyNlyydAauTMvLwpLGOYpAdGhwhz5tz51J88P/jVGhXgg==", "ebf7e3b6-bb5f-4014-883d-6eb92532d659" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "SmartPhones",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Used for delete");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ebc67940-e09f-4287-8cef-9ec70297314d", "AQAAAAIAAYagAAAAEJVMA0vheBfAqOxYsG/uqGnKqRa9tAk6b4pvuZhHizmO9uRK2zrj11cbCA4Z+UacrA==", "a46e2e31-ce27-418d-9a79-f784ada83b77" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2068f2ad-35a8-440a-a877-1d2c4423fa26", "AQAAAAIAAYagAAAAED1kuwRuOGymYMwTe0WvA9G888jsYy5PBG4/jLIFGfM1lO5CjuNmp0SFQJ306wlrUw==", "a3ae49d5-5e3f-41aa-98c8-c100da552b7a" });

            migrationBuilder.UpdateData(
                table: "SmartPhones",
                keyColumn: "Id",
                keyValue: 1,
                column: "isDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "SmartPhones",
                keyColumn: "Id",
                keyValue: 2,
                column: "isDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "SmartPhones",
                keyColumn: "Id",
                keyValue: 3,
                column: "isDeleted",
                value: false);
        }
    }
}
