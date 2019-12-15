using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Game.Migrations
{
    public partial class GameMigration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "endTime", "startTime" },
                values: new object[] { new DateTime(2019, 12, 12, 15, 18, 28, 486, DateTimeKind.Local).AddTicks(1430), new DateTime(2019, 12, 11, 13, 18, 28, 482, DateTimeKind.Local).AddTicks(6588) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "endTime", "startTime" },
                values: new object[] { new DateTime(2019, 12, 12, 14, 12, 55, 927, DateTimeKind.Local).AddTicks(6542), new DateTime(2019, 12, 11, 12, 12, 55, 926, DateTimeKind.Local).AddTicks(8862) });
        }
    }
}
