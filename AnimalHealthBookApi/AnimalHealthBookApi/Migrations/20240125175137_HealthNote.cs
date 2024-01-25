using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalHealthBookApi.Migrations
{
    /// <inheritdoc />
    public partial class HealthNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthNote_Animals_AnimalId",
                table: "HealthNote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HealthNote",
                table: "HealthNote");

            migrationBuilder.RenameTable(
                name: "HealthNote",
                newName: "HealthNotes");

            migrationBuilder.RenameIndex(
                name: "IX_HealthNote_AnimalId",
                table: "HealthNotes",
                newName: "IX_HealthNotes_AnimalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HealthNotes",
                table: "HealthNotes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthNotes_Animals_AnimalId",
                table: "HealthNotes",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthNotes_Animals_AnimalId",
                table: "HealthNotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HealthNotes",
                table: "HealthNotes");

            migrationBuilder.RenameTable(
                name: "HealthNotes",
                newName: "HealthNote");

            migrationBuilder.RenameIndex(
                name: "IX_HealthNotes_AnimalId",
                table: "HealthNote",
                newName: "IX_HealthNote_AnimalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HealthNote",
                table: "HealthNote",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthNote_Animals_AnimalId",
                table: "HealthNote",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
