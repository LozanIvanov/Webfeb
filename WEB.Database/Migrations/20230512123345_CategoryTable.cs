using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Database.Migrations
{
    public partial class CategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainImagess",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: null );
        


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainImagess",
                table: "Categories");
        }
    }
}
