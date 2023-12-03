using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JITC.Migrations
{
    public partial class changementNomTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Vol_VolId",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Vol_VolId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Vol_Helicopter_HelicopterId",
                table: "Vol");

            migrationBuilder.DropForeignKey(
                name: "FK_Vol_Pilote_PiloteId",
                table: "Vol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vol",
                table: "Vol");

            migrationBuilder.RenameTable(
                name: "Vol",
                newName: "Vols");

            migrationBuilder.RenameIndex(
                name: "IX_Vol_PiloteId",
                table: "Vols",
                newName: "IX_Vols_PiloteId");

            migrationBuilder.RenameIndex(
                name: "IX_Vol_HelicopterId",
                table: "Vols",
                newName: "IX_Vols_HelicopterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vols",
                table: "Vols",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Vols_VolId",
                table: "Logs",
                column: "VolId",
                principalTable: "Vols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Vols_VolId",
                table: "Reservations",
                column: "VolId",
                principalTable: "Vols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vols_Helicopter_HelicopterId",
                table: "Vols",
                column: "HelicopterId",
                principalTable: "Helicopter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vols_Pilote_PiloteId",
                table: "Vols",
                column: "PiloteId",
                principalTable: "Pilote",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Vols_VolId",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Vols_VolId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Vols_Helicopter_HelicopterId",
                table: "Vols");

            migrationBuilder.DropForeignKey(
                name: "FK_Vols_Pilote_PiloteId",
                table: "Vols");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vols",
                table: "Vols");

            migrationBuilder.RenameTable(
                name: "Vols",
                newName: "Vol");

            migrationBuilder.RenameIndex(
                name: "IX_Vols_PiloteId",
                table: "Vol",
                newName: "IX_Vol_PiloteId");

            migrationBuilder.RenameIndex(
                name: "IX_Vols_HelicopterId",
                table: "Vol",
                newName: "IX_Vol_HelicopterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vol",
                table: "Vol",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Vol_VolId",
                table: "Logs",
                column: "VolId",
                principalTable: "Vol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Vol_VolId",
                table: "Reservations",
                column: "VolId",
                principalTable: "Vol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vol_Helicopter_HelicopterId",
                table: "Vol",
                column: "HelicopterId",
                principalTable: "Helicopter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vol_Pilote_PiloteId",
                table: "Vol",
                column: "PiloteId",
                principalTable: "Pilote",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
