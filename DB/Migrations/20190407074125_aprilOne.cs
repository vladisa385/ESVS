using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class aprilOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Field_Catalogs_CatalogId",
                table: "Field");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldValue_Field_FieldId",
                table: "FieldValue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FieldValue",
                table: "FieldValue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Field",
                table: "Field");

            migrationBuilder.RenameTable(
                name: "FieldValue",
                newName: "FieldValues");

            migrationBuilder.RenameTable(
                name: "Field",
                newName: "Fields");

            migrationBuilder.RenameIndex(
                name: "IX_FieldValue_FieldId",
                table: "FieldValues",
                newName: "IX_FieldValues_FieldId");

            migrationBuilder.RenameIndex(
                name: "IX_Field_CatalogId",
                table: "Fields",
                newName: "IX_Fields_CatalogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FieldValues",
                table: "FieldValues",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fields",
                table: "Fields",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_Catalogs_CatalogId",
                table: "Fields",
                column: "CatalogId",
                principalTable: "Catalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldValues_Fields_FieldId",
                table: "FieldValues",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fields_Catalogs_CatalogId",
                table: "Fields");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldValues_Fields_FieldId",
                table: "FieldValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FieldValues",
                table: "FieldValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fields",
                table: "Fields");

            migrationBuilder.RenameTable(
                name: "FieldValues",
                newName: "FieldValue");

            migrationBuilder.RenameTable(
                name: "Fields",
                newName: "Field");

            migrationBuilder.RenameIndex(
                name: "IX_FieldValues_FieldId",
                table: "FieldValue",
                newName: "IX_FieldValue_FieldId");

            migrationBuilder.RenameIndex(
                name: "IX_Fields_CatalogId",
                table: "Field",
                newName: "IX_Field_CatalogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FieldValue",
                table: "FieldValue",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Field",
                table: "Field",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Field_Catalogs_CatalogId",
                table: "Field",
                column: "CatalogId",
                principalTable: "Catalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldValue_Field_FieldId",
                table: "FieldValue",
                column: "FieldId",
                principalTable: "Field",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
