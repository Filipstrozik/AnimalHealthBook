using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalHealthBookApi.Migrations
{
    /// <inheritdoc />
    public partial class MigrationFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_AnimalTypes_AnimalTypeId",
                table: "Breeds");

            migrationBuilder.DropColumn(
                name: "Breed",
                table: "Animals");

            migrationBuilder.AddColumn<int>(
                name: "Mood",
                table: "HealthNotes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "BreedId",
                table: "Animals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Animals_BreedId",
                table: "Animals",
                column: "BreedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Breeds_BreedId",
                table: "Animals",
                column: "BreedId",
                principalTable: "Breeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_AnimalTypes_AnimalTypeId",
                table: "Breeds",
                column: "AnimalTypeId",
                principalTable: "AnimalTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Breeds_BreedId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_AnimalTypes_AnimalTypeId",
                table: "Breeds");

            migrationBuilder.DropIndex(
                name: "IX_Animals_BreedId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "Mood",
                table: "HealthNotes");

            migrationBuilder.DropColumn(
                name: "BreedId",
                table: "Animals");

            migrationBuilder.AddColumn<string>(
                name: "Breed",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_AnimalTypes_AnimalTypeId",
                table: "Breeds",
                column: "AnimalTypeId",
                principalTable: "AnimalTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
