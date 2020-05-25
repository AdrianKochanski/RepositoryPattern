using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseRepPattern.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(nullable: false),
                    surname = table.Column<string>(nullable: true),
                    login = table.Column<string>(nullable: false),
                    passwordHash = table.Column<byte[]>(nullable: false),
                    passwordSalt = table.Column<byte[]>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    lastActive = table.Column<DateTime>(nullable: false),
                    dateOfBirth = table.Column<DateTime>(nullable: false),
                    gender = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    number = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: false),
                    street = table.Column<string>(nullable: false),
                    city = table.Column<string>(nullable: false),
                    postalcode = table.Column<string>(nullable: false),
                    houseNumber = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    creditcard = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    price = table.Column<decimal>(nullable: false),
                    warrantyEnd = table.Column<DateTime>(nullable: false),
                    category = table.Column<string>(nullable: true),
                    isNew = table.Column<bool>(nullable: false),
                    customerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.id);
                    table.ForeignKey(
                        name: "FK_Items_Customers_customerId",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    dateOrder = table.Column<DateTime>(nullable: false),
                    dateDelivery = table.Column<DateTime>(nullable: false),
                    paymentType = table.Column<string>(nullable: false),
                    isPaid = table.Column<bool>(nullable: false),
                    customerId = table.Column<int>(nullable: false),
                    country = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: false),
                    postalCode = table.Column<string>(nullable: false),
                    street = table.Column<string>(nullable: false),
                    houseNr = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_customerId",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    itemId = table.Column<int>(nullable: false),
                    orderId = table.Column<int>(nullable: false),
                    amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.itemId, x.orderId });
                    table.ForeignKey(
                        name: "FK_OrderItems_Items_itemId",
                        column: x => x.itemId,
                        principalTable: "Items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_orderId",
                        column: x => x.orderId,
                        principalTable: "Orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_customerId",
                table: "Items",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_orderId",
                table: "OrderItems",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_customerId",
                table: "Orders",
                column: "customerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
