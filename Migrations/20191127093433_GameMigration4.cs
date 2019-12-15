using Microsoft.EntityFrameworkCore.Migrations;

namespace Game.Migrations
{
    public partial class GameMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "TeamsId", "endTime", "score", "startTime", "teamA", "teamB" },
                values: new object[] { 500, null, "05:00", " 3 - 1", "03:00", 1, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 500);
        }
    }
}
