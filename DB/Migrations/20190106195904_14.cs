using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class _14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Field_Type_TypeId",
                table: "Field");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropIndex(
                name: "IX_Field_TypeId",
                table: "Field");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Field");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Catalogs",
                newName: "Text");

            migrationBuilder.AddColumn<string>(
                name: "Caption",
                table: "Field",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsForeignKey",
                table: "Field",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Length",
                table: "Field",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NotNull",
                table: "Field",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Field",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RoleDescription",
                table: "AspNetRoles",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Caption",
                table: "Field");

            migrationBuilder.DropColumn(
                name: "IsForeignKey",
                table: "Field");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Field");

            migrationBuilder.DropColumn(
                name: "NotNull",
                table: "Field");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Field");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Catalogs",
                newName: "Description");

            migrationBuilder.AddColumn<Guid>(
                name: "TypeId",
                table: "Field",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "RoleDescription",
                table: "AspNetRoles",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Field_TypeId",
                table: "Field",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Field_Type_TypeId",
                table: "Field",
                column: "TypeId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
