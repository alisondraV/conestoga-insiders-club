using Microsoft.EntityFrameworkCore.Migrations;

namespace ConestogaInsidersClub.Data.Migrations
{
    public partial class MoveReceivePromotionalEmailsToPreferencesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "receive_promotional_emails",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "receive_promotional_emails",
                table: "preferences",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "receive_promotional_emails",
                table: "preferences");

            migrationBuilder.AddColumn<bool>(
                name: "receive_promotional_emails",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
