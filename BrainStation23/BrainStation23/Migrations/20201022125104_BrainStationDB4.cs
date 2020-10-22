using Microsoft.EntityFrameworkCore.Migrations;

namespace BrainStation23.Migrations
{
    public partial class BrainStationDB4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vote");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vote",
                columns: table => new
                {
                    VID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comId = table.Column<int>(type: "int", nullable: false),
                    down = table.Column<int>(type: "int", nullable: false),
                    up = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vote", x => x.VID);
                    table.ForeignKey(
                        name: "FK_vote_comment_comId",
                        column: x => x.comId,
                        principalTable: "comment",
                        principalColumn: "comId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_vote_comId",
                table: "vote",
                column: "comId");
        }
    }
}
