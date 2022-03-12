using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyManager.Data.Migrations
{
    public partial class UserTeamaddedIsDrafted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDrafted",
                table: "UserTeams",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDrafted",
                table: "UserTeams");
        }
    }
}
