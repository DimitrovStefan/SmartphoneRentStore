using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartphoneRentStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class isDeletedInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "SmartPhones");

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
        }
    }
}
