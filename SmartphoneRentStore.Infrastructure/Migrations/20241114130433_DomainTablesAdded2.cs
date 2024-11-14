using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartphoneRentStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DomainTablesAdded2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SmartPhones_Categories_CategoryId",
                table: "SmartPhones");

            migrationBuilder.DropForeignKey(
                name: "FK_SmartPhones_Suppliers_SupplierId",
                table: "SmartPhones");

            migrationBuilder.AddForeignKey(
                name: "FK_SmartPhones_Categories_CategoryId",
                table: "SmartPhones",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SmartPhones_Suppliers_SupplierId",
                table: "SmartPhones",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SmartPhones_Categories_CategoryId",
                table: "SmartPhones");

            migrationBuilder.DropForeignKey(
                name: "FK_SmartPhones_Suppliers_SupplierId",
                table: "SmartPhones");

            migrationBuilder.AddForeignKey(
                name: "FK_SmartPhones_Categories_CategoryId",
                table: "SmartPhones",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SmartPhones_Suppliers_SupplierId",
                table: "SmartPhones",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
