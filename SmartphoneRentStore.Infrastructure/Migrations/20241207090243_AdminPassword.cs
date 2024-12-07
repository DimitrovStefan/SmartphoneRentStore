using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartphoneRentStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdminPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0827ba07-dee3-4244-b882-e4113dcee101",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43e04a14-9e00-43ed-847f-0db85c7eae02", "AQAAAAIAAYagAAAAEO5mxFSEAfysExUtsrvix4fbBFAfoWahpBYxi6xdkwI9pkAptW3r9NvE9JbXGkPUbQ==", "b4881871-42ee-43b5-ae70-2d1fbbd1db33" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0355e7f-586a-4daf-83a2-36b48870aa04", "AQAAAAIAAYagAAAAEDeK3Rpbq9SOiOTbC6wFVsAR4MKtvs9Vv58Xs71QkoXSuCcXcDv6XMSlWGDkT2yeOw==", "7dbc11ab-47c7-4bbf-b166-7b02240adf2b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ab0c686-662f-47d9-9fd7-7c2b936f3579", "AQAAAAIAAYagAAAAEN8sCOJsSLWPyYRO9yAqYLnEVmVIP1MjZEDwBVNUNolvZoTZN0c7M+QnyGF8iyYSIQ==", "b34a23e4-d85a-411e-87a1-1af4cce41710" });
        }
    }
}
