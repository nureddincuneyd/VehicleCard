using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleCard.DAL.Migrations
{
    public partial class newSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "ProImgUrl", "ProKG", "ProM3", "ProName", "Status" },
                values: new object[] { 1, "", 150, 300, "", true });

            migrationBuilder.InsertData(
                table: "ProductsWithVehicles",
                columns: new[] { "Id", "AvailableCapKG", "AvailableCapM3", "ProductsId", "Status", "VehiclesId" },
                values: new object[] { 1, 1500, 350, 1, true, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductsWithVehicles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
