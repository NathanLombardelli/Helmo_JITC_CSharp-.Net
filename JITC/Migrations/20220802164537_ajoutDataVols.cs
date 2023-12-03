using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JITC.Migrations
{
    public partial class ajoutDataVols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vols",
                columns: new[] { "Id", "AeroportArriverId", "AeroportDepartId", "ArriverFinal", "ArriverPrevu", "DepartFinal", "DepartPrevu", "HelicopterId", "PiloteId", "RaisonRetard" },
                values: new object[,]
                {
                    { 1, 1, 2, new DateTime(2022, 5, 9, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 9, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 9, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 9, 10, 30, 0, 0, DateTimeKind.Unspecified), 1, 1, "" },
                    { 2, 3, 4, new DateTime(2022, 8, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 1, 16, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), 2, 2, "détour car tempête" },
                    { 3, 1, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 14, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, "" },
                    { 4, 2, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 21, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, 2, "" },
                    { 5, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 5, 16, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 5, 12, 30, 0, 0, DateTimeKind.Unspecified), 2, 1, "" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vols",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vols",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vols",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vols",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vols",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
