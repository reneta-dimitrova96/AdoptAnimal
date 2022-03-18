using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdoptAnimal.Data.Migrations
{
    public partial class AddednewmodelPetImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Pets_PetId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_PetId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "Images");

            migrationBuilder.CreateTable(
                name: "PetImage",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PetId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetImage_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PetImage_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PetImage_AuthorId",
                table: "PetImage",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_PetImage_IsDeleted",
                table: "PetImage",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PetImage_PetId",
                table: "PetImage",
                column: "PetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetImage");

            migrationBuilder.AddColumn<int>(
                name: "PetId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_PetId",
                table: "Images",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Pets_PetId",
                table: "Images",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
