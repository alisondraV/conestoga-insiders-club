using Microsoft.EntityFrameworkCore.Migrations;

namespace ConestogaInsidersClub.Data.Migrations
{
    public partial class AddExtendedAddressInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_TO_addresses",
                table: "addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK__addresse__5CF1C59A90B364F3",
                table: "addresses");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "addresses");

            migrationBuilder.AddColumn<int>(
                name: "MailingAddressAddressId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShippingAddressAddressId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "addresses",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_addresses",
                table: "addresses",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MailingAddressAddressId",
                table: "AspNetUsers",
                column: "MailingAddressAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ShippingAddressAddressId",
                table: "AspNetUsers",
                column: "ShippingAddressAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_addresses_MailingAddressAddressId",
                table: "AspNetUsers",
                column: "MailingAddressAddressId",
                principalTable: "addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_addresses_ShippingAddressAddressId",
                table: "AspNetUsers",
                column: "ShippingAddressAddressId",
                principalTable: "addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_addresses_MailingAddressAddressId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_addresses_ShippingAddressAddressId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MailingAddressAddressId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ShippingAddressAddressId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_addresses",
                table: "addresses");

            migrationBuilder.DropColumn(
                name: "MailingAddressAddressId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ShippingAddressAddressId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "addresses");

            migrationBuilder.AddColumn<string>(
                name: "user_id",
                table: "addresses",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK__addresse__5CF1C59A90B364F3",
                table: "addresses",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_TO_addresses",
                table: "addresses",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
