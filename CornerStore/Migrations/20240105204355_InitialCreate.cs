using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CornerStore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cashiers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cashiers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CashierId = table.Column<int>(type: "integer", nullable: false),
                    PaidOnDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Cashiers_CashierId",
                        column: x => x.CashierId,
                        principalTable: "Cashiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductName = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Brand = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cashiers",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Donna", "Franklin" },
                    { 2, "John", "Smith" },
                    { 3, "Emily", "Johnson" },
                    { 4, "Michael", "Williams" },
                    { 5, "Sophia", "Davis" },
                    { 6, "Daniel", "Miller" },
                    { 7, "Olivia", "Jones" },
                    { 8, "Ethan", "Moore" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Printed Material" },
                    { 2, "Beverages" },
                    { 3, "Snacks" },
                    { 4, "Personal Care" },
                    { 5, "Household Items" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CashierId", "PaidOnDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 6, new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 7, new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 8, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 1, null },
                    { 10, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "Price", "ProductName" },
                values: new object[,]
                {
                    { 1, "Publisher X", 1, 4.99m, "Magazine A" },
                    { 2, "Daily News", 1, 1.99m, "Newspaper B" },
                    { 3, "Coca-Cola", 2, 0.99m, "Diet Coke" },
                    { 4, "SnackCo", 3, 2.49m, "Potato Chips" },
                    { 5, "CleanSmile", 4, 3.99m, "Toothpaste" },
                    { 6, "SoftTouch", 5, 5.99m, "Paper Towels" },
                    { 7, "HealthGuard", 4, 8.99m, "Multivitamins" },
                    { 8, "PowerCell", 5, 6.49m, "AA Batteries" },
                    { 9, "WriteRight", 5, 1.79m, "Notepad" },
                    { 10, "SweetTreat", 3, 1.49m, "Chocolate Bar" },
                    { 11, "SilkyLocks", 4, 4.49m, "Shampoo" },
                    { 12, "CleanUp", 5, 7.99m, "Trash Bags" },
                    { 13, "GermGuard", 4, 2.99m, "Hand Sanitizer" },
                    { 14, "BrightBeam", 5, 9.99m, "Flashlight" },
                    { 15, "PowerUp", 5, 19.99m, "Laptop Charger" },
                    { 16, "HealthyBite", 3, 3.29m, "Granola Bars" },
                    { 17, "SparkleClean", 5, 2.99m, "Dish Soap" },
                    { 18, "ReliefRx", 4, 4.79m, "Pain Reliever" },
                    { 19, "SoundWave", 5, 14.99m, "Earbuds" },
                    { 20, "PrintMaster", 5, 6.99m, "Printer Paper" },
                    { 21, "FreshBreath", 4, 3.49m, "Mouthwash" },
                    { 22, "NoteMaster", 5, 2.49m, "Notebook" },
                    { 23, "BoostFuel", 2, 2.99m, "Energy Drink" },
                    { 24, "SoftGlow", 4, 4.29m, "Hand Lotion" },
                    { 25, "DataSaver", 5, 8.49m, "USB Flash Drive" }
                });

            migrationBuilder.InsertData(
                table: "OrderProducts",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 1, 8, 2 },
                    { 3, 2, 3, 6 },
                    { 4, 2, 10, 4 },
                    { 5, 2, 4, 1 },
                    { 6, 3, 19, 1 },
                    { 7, 4, 18, 1 },
                    { 8, 5, 23, 2 },
                    { 9, 6, 2, 1 },
                    { 10, 7, 13, 1 },
                    { 11, 7, 24, 1 },
                    { 12, 8, 20, 10 },
                    { 13, 9, 16, 5 },
                    { 14, 9, 14, 1 },
                    { 15, 10, 7, 1 },
                    { 16, 10, 25, 1 },
                    { 17, 10, 12, 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CashierId",
                table: "Orders",
                column: "CashierId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Cashiers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
