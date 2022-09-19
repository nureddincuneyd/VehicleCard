using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleCard.DAL.Migrations
{
    public partial class addSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "Status", "UserFullName", "UserMail", "UserPass" },
                values: new object[] { 1, true, "Nureddin Cüneyd ERDOĞAN", "NCE@netlog.com", "123" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
