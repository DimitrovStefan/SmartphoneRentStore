using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartphoneRentStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DomainTablesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Category identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Category name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                },
                comment: "Smartphone category");

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Supplier identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Supplier phone number"),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Supplier based city"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Smartphone supplier");

            migrationBuilder.CreateTable(
                name: "SmartPhones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Smartphone identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Smartphone title"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Smartphone description"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Smartphone image url"),
                    PricePerMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Monthfly price"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Category identifier"),
                    SupplierId = table.Column<int>(type: "int", nullable: false, comment: "Supplier identifier"),
                    Renterid = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "User id of the renterer")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmartPhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmartPhones_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SmartPhones_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Smartphone to rent");

            migrationBuilder.CreateIndex(
                name: "IX_SmartPhones_CategoryId",
                table: "SmartPhones",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SmartPhones_SupplierId",
                table: "SmartPhones",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_UserId",
                table: "Suppliers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SmartPhones");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
