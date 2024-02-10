using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalHealthBookApi.Migrations
{
    /// <inheritdoc />
    public partial class AddCoatEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoatColor",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "CoatType",
                table: "Animals");

            migrationBuilder.AddColumn<Guid>(
                name: "CoatColorId",
                table: "Animals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CoatTypeId",
                table: "Animals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "CoatColors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoatColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoatTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoatTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_CoatColorId",
                table: "Animals",
                column: "CoatColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_CoatTypeId",
                table: "Animals",
                column: "CoatTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_CoatColors_CoatColorId",
                table: "Animals",
                column: "CoatColorId",
                principalTable: "CoatColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_CoatTypes_CoatTypeId",
                table: "Animals",
                column: "CoatTypeId",
                principalTable: "CoatTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_CoatColors_CoatColorId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Animals_CoatTypes_CoatTypeId",
                table: "Animals");

            migrationBuilder.DropTable(
                name: "CoatColors");

            migrationBuilder.DropTable(
                name: "CoatTypes");

            migrationBuilder.DropIndex(
                name: "IX_Animals_CoatColorId",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_CoatTypeId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "CoatColorId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "CoatTypeId",
                table: "Animals");

            migrationBuilder.AddColumn<string>(
                name: "CoatColor",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoatType",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
