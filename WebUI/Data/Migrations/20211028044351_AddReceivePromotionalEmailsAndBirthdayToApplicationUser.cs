using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConestogaInsidersClub.Data.Migrations
{
    public partial class AddReceivePromotionalEmailsAndBirthdayToApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "birthday",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "receive_promotional_emails",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "birthday",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "receive_promotional_emails",
                table: "AspNetUsers");
        }
    }
}
