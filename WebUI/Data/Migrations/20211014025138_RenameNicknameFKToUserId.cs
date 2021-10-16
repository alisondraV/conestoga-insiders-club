using Microsoft.EntityFrameworkCore.Migrations;

namespace ConestogaInsidersClub.Data.Migrations
{
    public partial class RenameNicknameFKToUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nickname",
                table: "wished_items",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "nickname",
                table: "reviews",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "nickname",
                table: "preferences",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "nickname",
                table: "orders",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_orders_nickname",
                table: "orders",
                newName: "IX_orders_user_id");

            migrationBuilder.RenameColumn(
                name: "nickname2",
                table: "friendships",
                newName: "user_id2");

            migrationBuilder.RenameColumn(
                name: "nickname1",
                table: "friendships",
                newName: "user_id1");

            migrationBuilder.RenameIndex(
                name: "IX_friendships_nickname2",
                table: "friendships",
                newName: "IX_friendships_user_id2");

            migrationBuilder.RenameColumn(
                name: "nickname",
                table: "cart_items",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "nickname",
                table: "addresses",
                newName: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "wished_items",
                newName: "nickname");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "reviews",
                newName: "nickname");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "preferences",
                newName: "nickname");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "orders",
                newName: "nickname");

            migrationBuilder.RenameIndex(
                name: "IX_orders_user_id",
                table: "orders",
                newName: "IX_orders_nickname");

            migrationBuilder.RenameColumn(
                name: "user_id2",
                table: "friendships",
                newName: "nickname2");

            migrationBuilder.RenameColumn(
                name: "user_id1",
                table: "friendships",
                newName: "nickname1");

            migrationBuilder.RenameIndex(
                name: "IX_friendships_user_id2",
                table: "friendships",
                newName: "IX_friendships_nickname2");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "cart_items",
                newName: "nickname");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "addresses",
                newName: "nickname");
        }
    }
}
