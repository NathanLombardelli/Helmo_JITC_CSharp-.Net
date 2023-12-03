using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JITC.Migrations
{
    public partial class logVolid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Vols_VolId",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_VolId",
                table: "Logs");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateIndex(
                name: "IX_Logs_VolId",
                table: "Logs",
                column: "VolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Vols_VolId",
                table: "Logs",
                column: "VolId",
                principalTable: "Vols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
