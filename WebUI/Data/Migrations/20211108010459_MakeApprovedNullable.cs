using Microsoft.EntityFrameworkCore.Migrations;

namespace ConestogaInsidersClub.Data.Migrations
{
    public partial class MakeApprovedNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_TO_preferences",
                table: "preferences");

            migrationBuilder.AlterColumn<bool>(
                name: "approved",
                table: "reviews",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddForeignKey(
                name: "FK_preferences_AspNetUsers_user_id",
                table: "preferences",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_preferences_AspNetUsers_user_id",
                table: "preferences");

            migrationBuilder.AlterColumn<bool>(
                name: "approved",
                table: "reviews",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_users_TO_preferences",
                table: "preferences",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
