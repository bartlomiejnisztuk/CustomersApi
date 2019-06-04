using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomersApi.DAL.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AddressTypeMapping_AddressType",
                table: "Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressTypeMapping",
                table: "AddressTypeMapping");

            migrationBuilder.DeleteData(
                table: "AddressTypeMapping",
                keyColumn: "AddressType",
                keyValue: null);

            migrationBuilder.DeleteData(
                table: "AddressTypeMapping",
                keyColumn: "AddressType",
                keyValue: null);

            migrationBuilder.DeleteData(
                table: "AddressTypeMapping",
                keyColumn: "AddressType",
                keyValue: null);

            migrationBuilder.RenameTable(
                name: "AddressTypeMapping",
                newName: "AddressTypeMappings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressTypeMappings",
                table: "AddressTypeMappings",
                column: "AddressType");

            migrationBuilder.InsertData(
                table: "AddressTypeMappings",
                columns: new[] { "AddressType", "AddressName" },
                values: new object[] { "D", "delivery address" });

            migrationBuilder.InsertData(
                table: "AddressTypeMappings",
                columns: new[] { "AddressType", "AddressName" },
                values: new object[] { "I", "invoice address" });

            migrationBuilder.InsertData(
                table: "AddressTypeMappings",
                columns: new[] { "AddressType", "AddressName" },
                values: new object[] { "S", "service address" });

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AddressTypeMappings_AddressType",
                table: "Addresses",
                column: "AddressType",
                principalTable: "AddressTypeMappings",
                principalColumn: "AddressType",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AddressTypeMappings_AddressType",
                table: "Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressTypeMappings",
                table: "AddressTypeMappings");

            migrationBuilder.DeleteData(
                table: "AddressTypeMappings",
                keyColumn: "AddressType",
                keyValue: "D");

            migrationBuilder.DeleteData(
                table: "AddressTypeMappings",
                keyColumn: "AddressType",
                keyValue: "I");

            migrationBuilder.DeleteData(
                table: "AddressTypeMappings",
                keyColumn: "AddressType",
                keyValue: "S");

            migrationBuilder.RenameTable(
                name: "AddressTypeMappings",
                newName: "AddressTypeMapping");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressTypeMapping",
                table: "AddressTypeMapping",
                column: "AddressType");

            migrationBuilder.InsertData(
                table: "AddressTypeMapping",
                columns: new[] { "AddressType", "AddressName" },
                values: new object[] { null, "delivery address" });

            migrationBuilder.InsertData(
                table: "AddressTypeMapping",
                columns: new[] { "AddressType", "AddressName" },
                values: new object[] { null, "invoice address" });

            migrationBuilder.InsertData(
                table: "AddressTypeMapping",
                columns: new[] { "AddressType", "AddressName" },
                values: new object[] { null, "service address" });

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AddressTypeMapping_AddressType",
                table: "Addresses",
                column: "AddressType",
                principalTable: "AddressTypeMapping",
                principalColumn: "AddressType",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
