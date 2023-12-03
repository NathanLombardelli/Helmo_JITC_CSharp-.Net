using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JITC.Migrations
{
    public partial class UserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23d6e9d7-8036-43f0-9cc6-19385cb02866",
                column: "ConcurrencyStamp",
                value: "25710df5-7445-429f-abe0-a016316b1e1a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83ccc92a-72ba-45e8-af2f-03400704e6d2",
                column: "ConcurrencyStamp",
                value: "52fb08d2-4913-4322-924c-2a810d605f6a");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "83ccc92a-72ba-45e8-af2f-03400704e6d2", "455d681b-784e-4f5f-9183-92cf2b177ba1" },
                    { "23d6e9d7-8036-43f0-9cc6-19385cb02866", "727df886-7a0c-4054-b16f-5ab4cb8ee996" },
                    { "83ccc92a-72ba-45e8-af2f-03400704e6d2", "8b0fd074-380b-42ca-8d93-fe8667880e82" },
                    { "83ccc92a-72ba-45e8-af2f-03400704e6d2", "b2346ce4-0260-488e-87ab-80596abfcc53" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "83ccc92a-72ba-45e8-af2f-03400704e6d2", "455d681b-784e-4f5f-9183-92cf2b177ba1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "23d6e9d7-8036-43f0-9cc6-19385cb02866", "727df886-7a0c-4054-b16f-5ab4cb8ee996" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "83ccc92a-72ba-45e8-af2f-03400704e6d2", "8b0fd074-380b-42ca-8d93-fe8667880e82" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "83ccc92a-72ba-45e8-af2f-03400704e6d2", "b2346ce4-0260-488e-87ab-80596abfcc53" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23d6e9d7-8036-43f0-9cc6-19385cb02866",
                column: "ConcurrencyStamp",
                value: "e2f23517-3142-428d-a5ce-4034ca095979");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83ccc92a-72ba-45e8-af2f-03400704e6d2",
                column: "ConcurrencyStamp",
                value: "08dbe2e7-df6c-4c49-8d24-630eb2d0ebb1");
        }
    }
}
