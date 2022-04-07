using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdoptAnimal.Data.Migrations
{
    public partial class AddedidtoArticleImageandPetImagemodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PetImages_IsDeleted",
                table: "PetImages");

            migrationBuilder.DropIndex(
                name: "IX_ArticleImages_IsDeleted",
                table: "ArticleImages");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "PetImages");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "PetImages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PetImages");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "PetImages");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "ArticleImages");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "ArticleImages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ArticleImages");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "ArticleImages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "PetImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "PetImages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PetImages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "PetImages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "ArticleImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "ArticleImages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ArticleImages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "ArticleImages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PetImages_IsDeleted",
                table: "PetImages",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleImages_IsDeleted",
                table: "ArticleImages",
                column: "IsDeleted");
        }
    }
}
