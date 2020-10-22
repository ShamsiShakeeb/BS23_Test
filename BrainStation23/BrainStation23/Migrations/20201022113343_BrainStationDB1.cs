using Microsoft.EntityFrameworkCore.Migrations;

namespace BrainStation23.Migrations
{
    public partial class BrainStationDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "post",
                columns: table => new
                {
                    PID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    post_data = table.Column<string>(nullable: true),
                    user = table.Column<string>(maxLength: 100, nullable: true),
                    date = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post", x => x.PID);
                });

            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    comId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment_Data = table.Column<string>(nullable: true),
                    user = table.Column<string>(nullable: true),
                    date = table.Column<string>(nullable: true),
                    PID = table.Column<int>(nullable: false),
                    PostPID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.comId);
                    table.ForeignKey(
                        name: "FK_comment_post_PostPID",
                        column: x => x.PostPID,
                        principalTable: "post",
                        principalColumn: "PID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vote",
                columns: table => new
                {
                    VID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    up = table.Column<int>(nullable: false),
                    down = table.Column<int>(nullable: false),
                    comId = table.Column<int>(nullable: false),
                    commentcomId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vote", x => x.VID);
                    table.ForeignKey(
                        name: "FK_vote_comment_commentcomId",
                        column: x => x.commentcomId,
                        principalTable: "comment",
                        principalColumn: "comId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comment_PostPID",
                table: "comment",
                column: "PostPID");

            migrationBuilder.CreateIndex(
                name: "IX_vote_commentcomId",
                table: "vote",
                column: "commentcomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vote");

            migrationBuilder.DropTable(
                name: "comment");

            migrationBuilder.DropTable(
                name: "post");
        }
    }
}
