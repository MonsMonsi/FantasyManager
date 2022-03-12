using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyManager.Data.Migrations
{
    public partial class UserTeamaddedLogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "UserTeams",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "UserTeams");
        }
    }
}
