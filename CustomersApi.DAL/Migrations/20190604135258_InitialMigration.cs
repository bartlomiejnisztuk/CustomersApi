using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomersApi.DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressTypeMapping",
                columns: table => new
                {
                    AddressType = table.Column<string>(nullable: false),
                    AddressName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTypeMapping", x => x.AddressType);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<string>(maxLength: 5, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Street = table.Column<string>(maxLength: 100, nullable: true),
                    ZIP = table.Column<string>(maxLength: 20, nullable: true),
                    City = table.Column<string>(maxLength: 100, nullable: true),
                    Country = table.Column<string>(maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => new { x.CustomerId, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    CustomerId = table.Column<string>(nullable: false),
                    AddressType = table.Column<string>(nullable: false),
                    CustomerName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Street = table.Column<string>(maxLength: 100, nullable: true),
                    ZIP = table.Column<string>(maxLength: 20, nullable: true),
                    City = table.Column<string>(maxLength: 100, nullable: true),
                    Country = table.Column<string>(maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => new { x.CustomerId, x.AddressType });
                    table.ForeignKey(
                        name: "FK_Addresses_AddressTypeMapping_AddressType",
                        column: x => x.AddressType,
                        principalTable: "AddressTypeMapping",
                        principalColumn: "AddressType",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Customers_CustomerId_CustomerName",
                        columns: x => new { x.CustomerId, x.CustomerName },
                        principalTable: "Customers",
                        principalColumns: new[] { "CustomerId", "Name" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AddressTypeMapping",
                columns: new[] { "AddressType", "AddressName" },
                values: new object[] { "D", "delivery address" });

            migrationBuilder.InsertData(
                table: "AddressTypeMapping",
                columns: new[] { "AddressType", "AddressName" },
                values: new object[] { "I", "invoice address" });

            migrationBuilder.InsertData(
                table: "AddressTypeMapping",
                columns: new[] { "AddressType", "AddressName" },
                values: new object[] { "S", "service address" });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AddressType",
                table: "Addresses",
                column: "AddressType");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId_CustomerName",
                table: "Addresses",
                columns: new[] { "CustomerId", "CustomerName" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AddressTypeMapping");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
