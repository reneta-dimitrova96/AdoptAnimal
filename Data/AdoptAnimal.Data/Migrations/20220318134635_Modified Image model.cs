using Microsoft.EntityFrameworkCore.Migrations;

namespace AdoptAnimal.Data.Migrations
{
    public partial class ModifiedImagemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetImage_AspNetUsers_AuthorId",
                table: "PetImage");

            migrationBuilder.DropForeignKey(
                name: "FK_PetImage_Pets_PetId",
                table: "PetImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PetImage",
                table: "PetImage");

            migrationBuilder.RenameTable(
                name: "PetImage",
                newName: "PetImages");

            migrationBuilder.RenameIndex(
                name: "IX_PetImage_PetId",
                table: "PetImages",
                newName: "IX_PetImages_PetId");

            migrationBuilder.RenameIndex(
                name: "IX_PetImage_IsDeleted",
                table: "PetImages",
                newName: "IX_PetImages_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_PetImage_AuthorId",
                table: "PetImages",
                newName: "IX_PetImages_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PetImages",
                table: "PetImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PetImages_AspNetUsers_AuthorId",
                table: "PetImages",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PetImages_Pets_PetId",
                table: "PetImages",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetImages_AspNetUsers_AuthorId",
                table: "PetImages");

            migrationBuilder.DropForeignKey(
                name: "FK_PetImages_Pets_PetId",
                table: "PetImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PetImages",
                table: "PetImages");

            migrationBuilder.RenameTable(
                name: "PetImages",
                newName: "PetImage");

            migrationBuilder.RenameIndex(
                name: "IX_PetImages_PetId",
                table: "PetImage",
                newName: "IX_PetImage_PetId");

            migrationBuilder.RenameIndex(
                name: "IX_PetImages_IsDeleted",
                table: "PetImage",
                newName: "IX_PetImage_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_PetImages_AuthorId",
                table: "PetImage",
                newName: "IX_PetImage_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PetImage",
                table: "PetImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PetImage_AspNetUsers_AuthorId",
                table: "PetImage",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PetImage_Pets_PetId",
                table: "PetImage",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
