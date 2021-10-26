using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoProjectLearn.Migrations
{
    public partial class updatepizzatables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CName",
                table: "pizzas");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "pizzas");

            migrationBuilder.AddColumn<string>(
                name: "PName",
                table: "pizzas",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PName",
                table: "pizzas");

            migrationBuilder.AddColumn<string>(
                name: "CName",
                table: "pizzas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "pizzas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
