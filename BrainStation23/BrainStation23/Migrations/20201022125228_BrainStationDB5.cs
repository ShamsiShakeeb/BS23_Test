using Microsoft.EntityFrameworkCore.Migrations;

namespace BrainStation23.Migrations
{
    public partial class BrainStationDB5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "vote",
                table: "comment",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "vote",
                table: "comment");
        }
    }
}
