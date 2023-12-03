using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JITC.Migrations
{
    public partial class AjoutDeDatas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Aeroports",
                columns: new[] { "Id", "Latitude", "Longitude", "Name" },
                values: new object[,]
                {
                    { 1, "50.64318", "5.46083", "Liège" },
                    { 2, "50.46434", "4.45966", "Charleroi" },
                    { 3, "50.90114", "4.48539", "Bruxelles" },
                    { 4, "51.20467", "2.86983", "Oostende" }
                });

            migrationBuilder.InsertData(
                table: "Helicopter",
                columns: new[] { "Id", "Capacity", "Motor", "Name", "Speed", "Statut" },
                values: new object[,]
                {
                    { 1, 5, "deux turbines du modèle de Rolls Royce 250-C20F", "Eurocopter AS 355 F1/F2 Ecureuil III", 220, "ok" },
                    { 2, 4, "une turbine du type Rolls Royce 250-C20B", "Bell 206 JetRanger", 190, "ok" },
                    { 3, 3, "un piston du type Lycoming modèle IO-540", "Robinson R44 Raven II", 190, "ok" }
                });

            migrationBuilder.InsertData(
                table: "Pilote",
                columns: new[] { "Id", "Email", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, "D.Balav@jitc.com", "Balav", "Danièle" },
                    { 2, "T.Sabine@jitc.com", "Sabine", "Thierry" },
                    { 3, "E.Coptère@jitc.com", "Coptère", "Eli" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Aeroports",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Aeroports",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Aeroports",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Aeroports",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Helicopter",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Helicopter",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Helicopter",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pilote",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pilote",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pilote",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
