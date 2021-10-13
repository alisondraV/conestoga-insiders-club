using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConestogaInsidersClub.Data.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase(
                collation: "SQL_Latin1_General_CP1_CI_AS");

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

            migrationBuilder.CreateTable(
                name: "games",
                columns: table => new
                {
                    game_id = table.Column<int>(type: "int", nullable: false),
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
                name: "addresses",
                columns: table => new
                {
                    nickname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    address1 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    address2 = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    city = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    province = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    country = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    postal_code = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__addresse__5CF1C59A90B364F3", x => x.nickname);
                    table.ForeignKey(
                        name: "FK_users_TO_addresses",
                        column: x => x.nickname,
                        principalTable: "users",
                        principalColumn: "nickname",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "friendships",
                columns: table => new
                {
                    nickname1 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    nickname2 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__friendsh__2EA53AFBF202847F", x => new { x.nickname1, x.nickname2 });
                    table.ForeignKey(
                        name: "FK_users_TO_friendships",
                        column: x => x.nickname1,
                        principalTable: "users",
                        principalColumn: "nickname",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_users_TO_friendships1",
                        column: x => x.nickname2,
                        principalTable: "users",
                        principalColumn: "nickname",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false),
                    nickname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_users_TO_orders",
                        column: x => x.nickname,
                        principalTable: "users",
                        principalColumn: "nickname",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "preferences",
                columns: table => new
                {
                    nickname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    platform = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    genre = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__preferen__5CF1C59A3E97A739", x => x.nickname);
                    table.ForeignKey(
                        name: "FK_game_genres_TO_preferences",
                        column: x => x.genre,
                        principalTable: "game_genres",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_users_TO_preferences",
                        column: x => x.nickname,
                        principalTable: "users",
                        principalColumn: "nickname",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cart_items",
                columns: table => new
                {
                    nickname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    game_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cart_ite__B30FD466E5616F1B", x => new { x.nickname, x.game_id });
                    table.ForeignKey(
                        name: "FK_games_TO_cart_items",
                        column: x => x.game_id,
                        principalTable: "games",
                        principalColumn: "game_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_users_TO_cart_items",
                        column: x => x.nickname,
                        principalTable: "users",
                        principalColumn: "nickname",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    nickname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    game_id = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<byte>(type: "tinyint", nullable: false),
                    description = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: true),
                    approved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__reviews__B30FD466087C2256", x => new { x.nickname, x.game_id });
                    table.ForeignKey(
                        name: "FK_games_TO_reviews",
                        column: x => x.game_id,
                        principalTable: "games",
                        principalColumn: "game_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_users_TO_reviews",
                        column: x => x.nickname,
                        principalTable: "users",
                        principalColumn: "nickname",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "wished_items",
                columns: table => new
                {
                    nickname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    game_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__wished_i__B30FD466E0DD1830", x => new { x.nickname, x.game_id });
                    table.ForeignKey(
                        name: "FK_games_TO_wished_items",
                        column: x => x.game_id,
                        principalTable: "games",
                        principalColumn: "game_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_users_TO_wished_items",
                        column: x => x.nickname,
                        principalTable: "users",
                        principalColumn: "nickname",
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

            migrationBuilder.CreateIndex(
                name: "IX_cart_items_game_id",
                table: "cart_items",
                column: "game_id");

            migrationBuilder.CreateIndex(
                name: "IX_friendships_nickname2",
                table: "friendships",
                column: "nickname2");

            migrationBuilder.CreateIndex(
                name: "IX_games_genre",
                table: "games",
                column: "genre");

            migrationBuilder.CreateIndex(
                name: "IX_order_items_game_id",
                table: "order_items",
                column: "game_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_nickname",
                table: "orders",
                column: "nickname");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "cart_items");

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
                name: "users");

            migrationBuilder.DropTable(
                name: "game_genres");

            migrationBuilder.AlterDatabase(
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");
        }
    }
}
