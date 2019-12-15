using Microsoft.EntityFrameworkCore.Migrations;

namespace Game.Migrations
{
    public partial class GameMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    Speed = table.Column<int>(nullable: false),
                    TeamsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[] { 1, "Riyadh", "Team 1" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[] { 2, "Dammam", "Team 2" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Age", "Height", "Name", "Speed", "TeamsId", "Weight" },
                values: new object[] { 1, 23, 184, "Essa", 26, 1, 80 });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Age", "Height", "Name", "Speed", "TeamsId", "Weight" },
                values: new object[] { 3, 25, 178, "Mohammed", 23, 1, 85 });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Age", "Height", "Name", "Speed", "TeamsId", "Weight" },
                values: new object[] { 2, 20, 180, "Ali", 30, 2, 75 });

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamsId",
                table: "Players",
                column: "TeamsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
