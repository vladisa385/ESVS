using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ESVS.Persistence.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldValues_Capacity",
                table: "Fields");

            migrationBuilder.CreateTable(
                name: "FieldValue",
                columns: table => new
                {
                    FieldId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldValue", x => new { x.FieldId, x.Date });
                    table.ForeignKey(
                        name: "FK_FieldValue_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FieldValue");

            migrationBuilder.AddColumn<int>(
                name: "FieldValues_Capacity",
                table: "Fields",
                nullable: false,
                defaultValue: 0);
        }
    }
}
