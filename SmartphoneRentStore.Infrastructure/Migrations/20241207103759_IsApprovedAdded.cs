using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartphoneRentStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IsApprovedAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "SmartPhones",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is smartphone approved by admin");

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

            migrationBuilder.UpdateData(
                table: "SmartPhones",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "SmartPhones",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "SmartPhones",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsApproved",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "SmartPhones");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0827ba07-dee3-4244-b882-e4113dcee101",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37dcb727-2e52-4e0e-9344-52bb777e82d0", "AQAAAAIAAYagAAAAEK77btiYiHyWvwbh4i+XHtJMa3dqV2x1Bn1Twt3Gg7j6g6yyzSWTdDthfTW5bqADrQ==", "8b369479-198b-4c25-b758-9af8ede0a418" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d587d3f0-1849-4a7b-9333-5551f2884ec7", "AQAAAAIAAYagAAAAEMLp6aJQ8OAaTGVE17lCaQzHZnijKSffJ2AwqUcLPu0eBAagofWOJRZdGoFbC5EtqA==", "71879f46-f9af-4471-95c8-2454d43a6eb1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd7af4d2-9f67-4d2c-ba46-d99dcdd8d029", "AQAAAAIAAYagAAAAEBJM+keI+99/FdWw+4Apv/0OD8ylFzWzBUACIV3KXc9ULxR+w2mc9kwEiHgvS9KG2A==", "b67fe948-160f-4fe4-b5bd-dea100230376" });
        }
    }
}
