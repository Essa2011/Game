using Microsoft.EntityFrameworkCore.Migrations;

namespace Game.Migrations
{
    public partial class GameMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_teamAId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_teamBId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_teamAId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_teamBId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "teamAId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "teamBId",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "TeamsId",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "teamA",
                table: "Games",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "teamB",
                table: "Games",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_TeamsId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_TeamsId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "TeamsId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "teamA",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "teamB",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "teamAId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "teamBId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_teamAId",
                table: "Games",
                column: "teamAId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_teamBId",
                table: "Games",
                column: "teamBId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_teamAId",
                table: "Games",
                column: "teamAId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_teamBId",
                table: "Games",
                column: "teamBId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
