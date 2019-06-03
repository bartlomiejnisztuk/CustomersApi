using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomersApi.DAL.Migrations
{
    public partial class AddressTypeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AddressTypeMapping",
                keyColumn: "AddressType",
                keyValue: "D");

            migrationBuilder.DeleteData(
                table: "AddressTypeMapping",
                keyColumn: "AddressType",
                keyValue: "I");

            migrationBuilder.DeleteData(
                table: "AddressTypeMapping",
                keyColumn: "AddressType",
                keyValue: "S");
        }
    }
}
