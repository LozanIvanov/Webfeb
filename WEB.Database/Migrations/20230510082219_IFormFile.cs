using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Database.Migrations
{
    public partial class IFormFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainImage",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainImage",
                table: "Categories");
        }
    }
}
