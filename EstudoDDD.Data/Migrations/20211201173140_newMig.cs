using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstudoDDD.Data.Migrations
{
    public partial class newMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "UpdateAt" },
                values: new object[] { new Guid("fad5c710-fb9c-41c1-8299-76c9d13c3211"), new DateTime(2021, 12, 1, 14, 31, 40, 46, DateTimeKind.Local).AddTicks(1782), "vini.souza00@gmail.com", "Vinicius", new DateTime(2021, 12, 1, 14, 31, 40, 47, DateTimeKind.Local).AddTicks(8224) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("fad5c710-fb9c-41c1-8299-76c9d13c3211"));
        }
    }
}
