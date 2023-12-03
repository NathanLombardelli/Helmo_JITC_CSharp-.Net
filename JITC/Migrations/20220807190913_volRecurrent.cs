using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JITC.Migrations
{
    public partial class volRecurrent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "recurrent",
                table: "Vols",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");


            migrationBuilder.UpdateData(
                table: "Vols",
                keyColumn: "Id",
                keyValue: 1,
                column: "recurrent",
                value: "");

            migrationBuilder.UpdateData(
                table: "Vols",
                keyColumn: "Id",
                keyValue: 2,
                column: "recurrent",
                value: "");

            migrationBuilder.UpdateData(
                table: "Vols",
                keyColumn: "Id",
                keyValue: 3,
                column: "recurrent",
                value: "");

            migrationBuilder.UpdateData(
                table: "Vols",
                keyColumn: "Id",
                keyValue: 4,
                column: "recurrent",
                value: "");

            migrationBuilder.UpdateData(
                table: "Vols",
                keyColumn: "Id",
                keyValue: 5,
                column: "recurrent",
                value: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "recurrent",
                table: "Vols");

        }
    }
}
