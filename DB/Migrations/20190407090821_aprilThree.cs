using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class aprilThree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Catalogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Catalogs");
        }
    }
}
