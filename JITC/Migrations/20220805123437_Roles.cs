using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JITC.Migrations
{
    public partial class Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "23d6e9d7-8036-43f0-9cc6-19385cb02866", "e2f23517-3142-428d-a5ce-4034ca095979", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "83ccc92a-72ba-45e8-af2f-03400704e6d2", "08dbe2e7-df6c-4c49-8d24-630eb2d0ebb1", "Pilote", "PILOTE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23d6e9d7-8036-43f0-9cc6-19385cb02866");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83ccc92a-72ba-45e8-af2f-03400704e6d2");
        }
    }
}
