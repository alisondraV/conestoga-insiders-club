using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConestogaInsidersClub.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase(
                collation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MailingAddressId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShippingAddressId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address1 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Address2 = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Province = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    Country = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    ExpirationYear = table.Column<int>(type: "int", nullable: false),
                    ExpirationMonth = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.CardId);
                    table.ForeignKey(
                        name: "FK_Cards_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "friendships",
                columns: table => new
                {
                    UserId1 = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    UserId2 = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_friendships", x => new { x.UserId1, x.UserId2 });
                    table.ForeignKey(
                        name: "FK_friendships_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_friendships_AspNetUsers_UserId2",
                        column: x => x.UserId2,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "game_genres",
                columns: table => new
                {
                    name = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__game_gen__72E12F1AB1253DCF", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_users_TO_orders",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "games",
                columns: table => new
                {
                    game_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    genre = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_games", x => x.game_id);
                    table.ForeignKey(
                        name: "FK_game_genres_TO_games",
                        column: x => x.genre,
                        principalTable: "game_genres",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => new { x.UserId, x.GameId });
                    table.ForeignKey(
                        name: "FK_CartItems_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItems_games_GameId",
                        column: x => x.GameId,
                        principalTable: "games",
                        principalColumn: "game_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "order_items",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false),
                    game_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__order_it__A9A773D52B4E4CFD", x => new { x.order_id, x.game_id });
                    table.ForeignKey(
                        name: "FK_games_TO_order_items",
                        column: x => x.game_id,
                        principalTable: "games",
                        principalColumn: "game_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orders_TO_order_items",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "preferences",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    platform = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    receive_promotional_emails = table.Column<bool>(type: "bit", nullable: true),
                    favourite_game_id = table.Column<int>(type: "int", nullable: true),
                    genre = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__preferen__5CF1C59A3E97A739", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_game_genres_TO_preferences",
                        column: x => x.genre,
                        principalTable: "game_genres",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_game_TO_preferences",
                        column: x => x.favourite_game_id,
                        principalTable: "games",
                        principalColumn: "game_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_preferences_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    game_id = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<byte>(type: "tinyint", nullable: false),
                    description = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: true),
                    approved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__reviews__B30FD466087C2256", x => new { x.user_id, x.game_id });
                    table.ForeignKey(
                        name: "FK_games_TO_reviews",
                        column: x => x.game_id,
                        principalTable: "games",
                        principalColumn: "game_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_users_TO_reviews",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "wished_items",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    game_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__wished_i__B30FD466E0DD1830", x => new { x.user_id, x.game_id });
                    table.ForeignKey(
                        name: "FK_games_TO_wished_items",
                        column: x => x.game_id,
                        principalTable: "games",
                        principalColumn: "game_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_users_TO_wished_items",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MailingAddressId",
                table: "AspNetUsers",
                column: "MailingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ShippingAddressId",
                table: "AspNetUsers",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_UserId",
                table: "Cards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_GameId",
                table: "CartItems",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_friendships_UserId2",
                table: "friendships",
                column: "UserId2");

            migrationBuilder.CreateIndex(
                name: "IX_games_genre",
                table: "games",
                column: "genre");

            migrationBuilder.CreateIndex(
                name: "IX_order_items_game_id",
                table: "order_items",
                column: "game_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_user_id",
                table: "orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_preferences_favourite_game_id",
                table: "preferences",
                column: "favourite_game_id");

            migrationBuilder.CreateIndex(
                name: "IX_preferences_genre",
                table: "preferences",
                column: "genre");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_game_id",
                table: "reviews",
                column: "game_id");

            migrationBuilder.CreateIndex(
                name: "IX_wished_items_game_id",
                table: "wished_items",
                column: "game_id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addresses_MailingAddressId",
                table: "AspNetUsers",
                column: "MailingAddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addresses_ShippingAddressId",
                table: "AspNetUsers",
                column: "ShippingAddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addresses_MailingAddressId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addresses_ShippingAddressId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "friendships");

            migrationBuilder.DropTable(
                name: "order_items");

            migrationBuilder.DropTable(
                name: "preferences");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "wished_items");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "games");

            migrationBuilder.DropTable(
                name: "game_genres");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MailingAddressId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ShippingAddressId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MailingAddressId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ShippingAddressId",
                table: "AspNetUsers");

            migrationBuilder.AlterDatabase(
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");
        }
    }
}
