using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalHealthBookApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "UploadFiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "MainImageId",
                table: "Animals",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileImageId",
                table: "Animals",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Animals_MainImageId",
                table: "Animals",
                column: "MainImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_ProfileImageId",
                table: "Animals",
                column: "ProfileImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_UploadFiles_MainImageId",
                table: "Animals",
                column: "MainImageId",
                principalTable: "UploadFiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_UploadFiles_ProfileImageId",
                table: "Animals",
                column: "ProfileImageId",
                principalTable: "UploadFiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_UploadFiles_MainImageId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Animals_UploadFiles_ProfileImageId",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_MainImageId",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_ProfileImageId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "MainImageId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "ProfileImageId",
                table: "Animals");

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "UploadFiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
