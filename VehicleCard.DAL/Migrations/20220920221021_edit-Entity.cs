using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleCard.DAL.Migrations
{
    public partial class editEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsWithVehicles_Product_ProductsId",
                table: "ProductsWithVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsWithVehicles_Vehicle_VehiclesId",
                table: "ProductsWithVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Model_vModelId",
                table: "Vehicle");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsWithVehicles",
                table: "ProductsWithVehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Model",
                table: "Model");

            migrationBuilder.RenameTable(
                name: "Vehicle",
                newName: "Vehicles");

            migrationBuilder.RenameTable(
                name: "ProductsWithVehicles",
                newName: "ProductsWithVehicle");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Model",
                newName: "Models");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_vModelId",
                table: "Vehicles",
                newName: "IX_Vehicles_vModelId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsWithVehicles_VehiclesId",
                table: "ProductsWithVehicle",
                newName: "IX_ProductsWithVehicle_VehiclesId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsWithVehicles_ProductsId",
                table: "ProductsWithVehicle",
                newName: "IX_ProductsWithVehicle_ProductsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsWithVehicle",
                table: "ProductsWithVehicle",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Models",
                table: "Models",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsWithVehicle_Products_ProductsId",
                table: "ProductsWithVehicle",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsWithVehicle_Vehicles_VehiclesId",
                table: "ProductsWithVehicle",
                column: "VehiclesId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Models_vModelId",
                table: "Vehicles",
                column: "vModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsWithVehicle_Products_ProductsId",
                table: "ProductsWithVehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsWithVehicle_Vehicles_VehiclesId",
                table: "ProductsWithVehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Models_vModelId",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsWithVehicle",
                table: "ProductsWithVehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Models",
                table: "Models");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "Vehicle");

            migrationBuilder.RenameTable(
                name: "ProductsWithVehicle",
                newName: "ProductsWithVehicles");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "Models",
                newName: "Model");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_vModelId",
                table: "Vehicle",
                newName: "IX_Vehicle_vModelId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsWithVehicle_VehiclesId",
                table: "ProductsWithVehicles",
                newName: "IX_ProductsWithVehicles_VehiclesId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsWithVehicle_ProductsId",
                table: "ProductsWithVehicles",
                newName: "IX_ProductsWithVehicles_ProductsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsWithVehicles",
                table: "ProductsWithVehicles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Model",
                table: "Model",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UserFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPass = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "Status", "UserFullName", "UserMail", "UserPass" },
                values: new object[] { 1, true, "Nureddin Cüneyd ERDOĞAN", "NCE@netlog.com", "123" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsWithVehicles_Product_ProductsId",
                table: "ProductsWithVehicles",
                column: "ProductsId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsWithVehicles_Vehicle_VehiclesId",
                table: "ProductsWithVehicles",
                column: "VehiclesId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Model_vModelId",
                table: "Vehicle",
                column: "vModelId",
                principalTable: "Model",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
