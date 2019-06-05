using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomersApi.DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressTypeMappings",
                columns: table => new
                {
                    AddressType = table.Column<string>(type: "varchar(1)", nullable: false),
                    AddressName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTypeMappings", x => x.AddressType);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Street = table.Column<string>(maxLength: 100, nullable: true),
                    ZIP = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    City = table.Column<string>(maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => new { x.CustomerId, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "varchar(5)", nullable: false),
                    AddressType = table.Column<string>(type: "varchar(1)", nullable: false),
                    CustomerName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Street = table.Column<string>(maxLength: 100, nullable: true),
                    ZIP = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    City = table.Column<string>(maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => new { x.CustomerId, x.AddressType });
                    table.ForeignKey(
                        name: "FK_Addresses_AddressTypeMappings_AddressType",
                        column: x => x.AddressType,
                        principalTable: "AddressTypeMappings",
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
                table: "AddressTypeMappings",
                columns: new[] { "AddressType", "AddressName" },
                values: new object[,]
                {
                    { "D", "delivery address" },
                    { "I", "invoice address" },
                    { "S", "service address" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Name", "City", "Country", "Street", "ZIP" },
                values: new object[] { "c1", "John", "New York", "US", "1st Avenue", "123" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "CustomerId", "AddressType", "City", "Country", "CustomerName", "Name", "Street", "ZIP" },
                values: new object[] { "c1", "D", "Dallas", "US", "John", "home", "2nd Avenue", "234" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "CustomerId", "AddressType", "City", "Country", "CustomerName", "Name", "Street", "ZIP" },
                values: new object[] { "c1", "I", "Dallas", "US", "John", "work", "2nd Avenue", "234" });

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
                name: "AddressTypeMappings");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
