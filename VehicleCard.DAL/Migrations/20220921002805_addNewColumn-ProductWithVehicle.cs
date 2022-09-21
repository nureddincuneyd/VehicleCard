using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleCard.DAL.Migrations
{
    public partial class addNewColumnProductWithVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OperationNumber",
                table: "ProductsWithVehicle");

            migrationBuilder.AddColumn<string>(
                name: "OperationName",
                table: "ProductsWithVehicle",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OperationName",
                table: "ProductsWithVehicle");

            migrationBuilder.AddColumn<int>(
                name: "OperationNumber",
                table: "ProductsWithVehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
