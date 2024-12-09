using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartphoneRentStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenterUserFKAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Suppliers_UserId",
                table: "Suppliers");

            migrationBuilder.AlterColumn<string>(
                name: "RenterId",
                table: "SmartPhones",
                type: "nvarchar(450)",
                nullable: true,
                comment: "User id of the renterer",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "User id of the renterer");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0827ba07-dee3-4244-b882-e4113dcee101",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8dd17c7-a593-4605-af60-806140c69245", "AQAAAAIAAYagAAAAEA0oTbouPRIpWj33D37zqe8yGB8+KPwFj94xUUI59bIBynxB/cMNzSwyKDtUXvEecw==", "b3d9306c-67a0-464a-9488-6f3e78a5414c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "959c6d4b-04d7-42a8-a5dc-87b0af9e66f8", "AQAAAAIAAYagAAAAEChJA27bHJF60zY0LBClDVs22VU1mBxCySKnugSQMtE1IWSru0YUnPd8bG6lhlJWAA==", "cad1cf61-ffa5-4434-a99e-c6637c03176b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f073898e-730d-4417-89e1-6f61fb42cd2f", "AQAAAAIAAYagAAAAEDTOd6x3s+zL2WujdKVcxqHhRCK5WfVhhOqTMYsojvLjlcFhmuyzhx3neJJilg2s3w==", "637e630e-d358-4720-8546-7a32908e9d6c" });

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_UserId",
                table: "Suppliers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SmartPhones_RenterId",
                table: "SmartPhones",
                column: "RenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_SmartPhones_AspNetUsers_RenterId",
                table: "SmartPhones",
                column: "RenterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SmartPhones_AspNetUsers_RenterId",
                table: "SmartPhones");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_UserId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_SmartPhones_RenterId",
                table: "SmartPhones");

            migrationBuilder.AlterColumn<string>(
                name: "RenterId",
                table: "SmartPhones",
                type: "nvarchar(max)",
                nullable: true,
                comment: "User id of the renterer",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true,
                oldComment: "User id of the renterer");

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

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_UserId",
                table: "Suppliers",
                column: "UserId");
        }
    }
}
