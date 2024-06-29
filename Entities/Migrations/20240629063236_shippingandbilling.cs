using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class shippingandbilling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ShippingMethods",
                columns: new[] { "Id", "Cost", "MethodName" },
                values: new object[] { 1, 5.99m, "Standard Shipping" });

            migrationBuilder.InsertData(
                table: "ShippingMethods",
                columns: new[] { "Id", "Cost", "MethodName" },
                values: new object[] { 2, 9.99m, "Express Shipping" });

            migrationBuilder.InsertData(
                table: "ShippingMethods",
                columns: new[] { "Id", "Cost", "MethodName" },
                values: new object[] { 3, 19.99m, "Next Day Shipping" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
