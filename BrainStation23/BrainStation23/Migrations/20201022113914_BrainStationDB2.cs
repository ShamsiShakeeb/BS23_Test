using Microsoft.EntityFrameworkCore.Migrations;

namespace BrainStation23.Migrations
{
    public partial class BrainStationDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comment_post_PostPID",
                table: "comment");

            migrationBuilder.DropForeignKey(
                name: "FK_vote_comment_commentcomId",
                table: "vote");

            migrationBuilder.DropIndex(
                name: "IX_vote_commentcomId",
                table: "vote");

            migrationBuilder.DropIndex(
                name: "IX_comment_PostPID",
                table: "comment");

            migrationBuilder.DropColumn(
                name: "commentcomId",
                table: "vote");

            migrationBuilder.DropColumn(
                name: "PostPID",
                table: "comment");

            migrationBuilder.CreateIndex(
                name: "IX_vote_comId",
                table: "vote",
                column: "comId");

            migrationBuilder.CreateIndex(
                name: "IX_comment_PID",
                table: "comment",
                column: "PID");

            migrationBuilder.AddForeignKey(
                name: "FK_comment_post_PID",
                table: "comment",
                column: "PID",
                principalTable: "post",
                principalColumn: "PID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vote_comment_comId",
                table: "vote",
                column: "comId",
                principalTable: "comment",
                principalColumn: "comId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comment_post_PID",
                table: "comment");

            migrationBuilder.DropForeignKey(
                name: "FK_vote_comment_comId",
                table: "vote");

            migrationBuilder.DropIndex(
                name: "IX_vote_comId",
                table: "vote");

            migrationBuilder.DropIndex(
                name: "IX_comment_PID",
                table: "comment");

            migrationBuilder.AddColumn<int>(
                name: "commentcomId",
                table: "vote",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostPID",
                table: "comment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_vote_commentcomId",
                table: "vote",
                column: "commentcomId");

            migrationBuilder.CreateIndex(
                name: "IX_comment_PostPID",
                table: "comment",
                column: "PostPID");

            migrationBuilder.AddForeignKey(
                name: "FK_comment_post_PostPID",
                table: "comment",
                column: "PostPID",
                principalTable: "post",
                principalColumn: "PID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_vote_comment_commentcomId",
                table: "vote",
                column: "commentcomId",
                principalTable: "comment",
                principalColumn: "comId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
