using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConestogaInsidersClub.Data.Migrations
{
    public partial class AddCustomUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_TO_addresses",
                table: "addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_users_TO_cart_items",
                table: "cart_items");

            migrationBuilder.DropForeignKey(
                name: "FK_users_TO_friendships",
                table: "friendships");

            migrationBuilder.DropForeignKey(
                name: "FK_users_TO_friendships1",
                table: "friendships");

            migrationBuilder.DropForeignKey(
                name: "FK_users_TO_orders",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_users_TO_preferences",
                table: "preferences");

            migrationBuilder.DropForeignKey(
                name: "FK_users_TO_reviews",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_users_TO_wished_items",
                table: "wished_items");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.AddColumn<string>(
                table: "AspNetUsers",
                name: "first_name",
                type: "nvarchar(50)",
                nullable: true,
                maxLength: 50);

            migrationBuilder.AddColumn<string>(
                table: "AspNetUsers",
                name: "last_name",
                type: "nvarchar(50)",
                nullable: true,
                maxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_users_TO_addresses",
                table: "addresses",
                column: "nickname",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_TO_cart_items",
                table: "cart_items",
                column: "nickname",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_TO_friendships",
                table: "friendships",
                column: "nickname1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_TO_friendships1",
                table: "friendships",
                column: "nickname2",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_TO_orders",
                table: "orders",
                column: "nickname",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_TO_preferences",
                table: "preferences",
                column: "nickname",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_TO_reviews",
                table: "reviews",
                column: "nickname",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_TO_wished_items",
                table: "wished_items",
                column: "nickname",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_TO_addresses",
                table: "addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_users_TO_cart_items",
                table: "cart_items");

            migrationBuilder.DropForeignKey(
                name: "FK_users_TO_friendships",
                table: "friendships");

            migrationBuilder.DropForeignKey(
                name: "FK_users_TO_friendships1",
                table: "friendships");

            migrationBuilder.DropForeignKey(
                name: "FK_users_TO_orders",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_users_TO_preferences",
                table: "preferences");

            migrationBuilder.DropForeignKey(
                name: "FK_users_TO_reviews",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_users_TO_wished_items",
                table: "wished_items");

            migrationBuilder.DropColumn(name: "first_name", table: "AspNetUsers");
            migrationBuilder.DropColumn(name: "last_name", table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    nickname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    first_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    last_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__users__5CF1C59ADF43945B", x => x.nickname);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_users_TO_addresses",
                table: "addresses",
                column: "nickname",
                principalTable: "users",
                principalColumn: "nickname",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_TO_cart_items",
                table: "cart_items",
                column: "nickname",
                principalTable: "users",
                principalColumn: "nickname",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_TO_friendships",
                table: "friendships",
                column: "nickname1",
                principalTable: "users",
                principalColumn: "nickname",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_TO_friendships1",
                table: "friendships",
                column: "nickname2",
                principalTable: "users",
                principalColumn: "nickname",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_TO_orders",
                table: "orders",
                column: "nickname",
                principalTable: "users",
                principalColumn: "nickname",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_TO_preferences",
                table: "preferences",
                column: "nickname",
                principalTable: "users",
                principalColumn: "nickname",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_TO_reviews",
                table: "reviews",
                column: "nickname",
                principalTable: "users",
                principalColumn: "nickname",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_TO_wished_items",
                table: "wished_items",
                column: "nickname",
                principalTable: "users",
                principalColumn: "nickname",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
