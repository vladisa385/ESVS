using Microsoft.EntityFrameworkCore.Migrations;

namespace ESVS.Persistence.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FieldValues_Capacity",
                table: "Fields",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldValues_Capacity",
                table: "Fields");
        }
    }
}
