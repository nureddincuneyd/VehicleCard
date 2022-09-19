using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleCard.DAL.Migrations
{
    public partial class addSeedData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CapacityKG = table.Column<int>(type: "int", nullable: false),
                    CapacityM3 = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vModelId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_Model_vModelId",
                        column: x => x.vModelId,
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Model",
                columns: new[] { "Id", "BrandName", "CapacityKG", "CapacityM3", "ModelName", "Status" },
                values: new object[] { 1, "Ford", 5000, 10000, "F-Max", true });

            migrationBuilder.InsertData(
                table: "Model",
                columns: new[] { "Id", "BrandName", "CapacityKG", "CapacityM3", "ModelName", "Status" },
                values: new object[] { 2, "BMC", 5000, 10000, "TGR 1846 ESS", true });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "Location", "Plate", "Status", "VehicleImgUrl", "vModelId" },
                values: new object[] { 2, "İstanbul", "34NE3406", true, "https://bmctugra.com/_cache/croped/gallery_2019-01-10_11-53-294-1044x623.jpg", 1 });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "Location", "Plate", "Status", "VehicleImgUrl", "vModelId" },
                values: new object[] { 1, "İstanbul", "34NE4906", true, "https://cdn.cetas.com.tr/Download/resources/f-max-1_4585289922_-1x-1_false.jpg", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_vModelId",
                table: "Vehicle",
                column: "vModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Model");
        }
    }
}
