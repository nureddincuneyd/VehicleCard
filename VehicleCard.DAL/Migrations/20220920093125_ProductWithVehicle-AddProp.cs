using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleCard.DAL.Migrations
{
    public partial class ProductWithVehicleAddProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OperationNumber",
                table: "ProductsWithVehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OperationNumber",
                table: "ProductsWithVehicles");
        }
    }
}
