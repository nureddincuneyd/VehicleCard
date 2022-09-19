using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleCard.DAL.Migrations
{
    public partial class dbModelEditted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProKG = table.Column<int>(type: "int", nullable: false),
                    ProM3 = table.Column<int>(type: "int", nullable: false),
                    ProImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductsWithVehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvailableCapKG = table.Column<int>(type: "int", nullable: false),
                    AvailableCapM3 = table.Column<int>(type: "int", nullable: false),
                    VehiclesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsWithVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsWithVehicles_Product_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsWithVehicles_Vehicle_VehiclesId",
                        column: x => x.VehiclesId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsWithVehicles_ProductsId",
                table: "ProductsWithVehicles",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsWithVehicles_VehiclesId",
                table: "ProductsWithVehicles",
                column: "VehiclesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsWithVehicles");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
