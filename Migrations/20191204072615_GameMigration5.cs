using Microsoft.EntityFrameworkCore.Migrations;

namespace Game.Migrations
{
    public partial class GameMigration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_TeamsId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_TeamsId",
                table: "Games");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 500);

            migrationBuilder.DropColumn(
                name: "TeamsId",
                table: "Games");

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "endTime", "score", "startTime", "teamA", "teamB" },
                values: new object[] { 1, "05:00", " 3 - 1", "03:00", 1, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "TeamsId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "TeamsId", "endTime", "score", "startTime", "teamA", "teamB" },
                values: new object[] { 500, null, "05:00", " 3 - 1", "03:00", 1, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Games_TeamsId",
                table: "Games",
                column: "TeamsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_TeamsId",
                table: "Games",
                column: "TeamsId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
