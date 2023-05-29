using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Database.Migrations
{
    public partial class CheckoutTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_CartItems_CartItemId",
                table: "Checkouts");

            migrationBuilder.AlterColumn<int>(
                name: "CartItemId",
                table: "Checkouts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_CartItems_CartItemId",
                table: "Checkouts",
                column: "CartItemId",
                principalTable: "CartItems",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_CartItems_CartItemId",
                table: "Checkouts");

            migrationBuilder.AlterColumn<int>(
                name: "CartItemId",
                table: "Checkouts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_CartItems_CartItemId",
                table: "Checkouts",
                column: "CartItemId",
                principalTable: "CartItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
