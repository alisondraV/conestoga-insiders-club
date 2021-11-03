using Microsoft.EntityFrameworkCore.Migrations;

namespace ConestogaInsidersClub.Data.Migrations
{
    public partial class AddFavouriteGameToPreferencesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "favourite_game_id",
                table: "preferences",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_preferences_favourite_game_id",
                table: "preferences",
                column: "favourite_game_id");

            migrationBuilder.AddForeignKey(
                name: "FK_preferences_games_favourite_game_id",
                table: "preferences",
                column: "favourite_game_id",
                principalTable: "games",
                principalColumn: "game_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_preferences_games_favourite_game_id",
                table: "preferences");

            migrationBuilder.DropIndex(
                name: "IX_preferences_favourite_game_id",
                table: "preferences");

            migrationBuilder.DropColumn(
                name: "favourite_game_id",
                table: "preferences");
        }
    }
}
