using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdoptAnimal.Data.Migrations
{
    public partial class ChangeModelName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Adds_AddId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Adds_AddForeignKey",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Statistics_Adds_AddId",
                table: "Statistics");

            migrationBuilder.DropTable(
                name: "Adds");

            migrationBuilder.RenameColumn(
                name: "AddId",
                table: "Statistics",
                newName: "AdId");

            migrationBuilder.RenameIndex(
                name: "IX_Statistics_AddId",
                table: "Statistics",
                newName: "IX_Statistics_AdId");

            migrationBuilder.RenameColumn(
                name: "AddForeignKey",
                table: "Pets",
                newName: "AdForeignKey");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_AddForeignKey",
                table: "Pets",
                newName: "IX_Pets_AdForeignKey");

            migrationBuilder.RenameColumn(
                name: "AddId",
                table: "Comments",
                newName: "AdId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_AddId",
                table: "Comments",
                newName: "IX_Comments_AdId");

            migrationBuilder.CreateTable(
                name: "Ads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ads_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ads_AuthorId",
                table: "Ads",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_IsDeleted",
                table: "Ads",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Ads_AdId",
                table: "Comments",
                column: "AdId",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Ads_AdForeignKey",
                table: "Pets",
                column: "AdForeignKey",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_Ads_AdId",
                table: "Statistics",
                column: "AdId",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Ads_AdId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Ads_AdForeignKey",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Statistics_Ads_AdId",
                table: "Statistics");

            migrationBuilder.DropTable(
                name: "Ads");

            migrationBuilder.RenameColumn(
                name: "AdId",
                table: "Statistics",
                newName: "AddId");

            migrationBuilder.RenameIndex(
                name: "IX_Statistics_AdId",
                table: "Statistics",
                newName: "IX_Statistics_AddId");

            migrationBuilder.RenameColumn(
                name: "AdForeignKey",
                table: "Pets",
                newName: "AddForeignKey");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_AdForeignKey",
                table: "Pets",
                newName: "IX_Pets_AddForeignKey");

            migrationBuilder.RenameColumn(
                name: "AdId",
                table: "Comments",
                newName: "AddId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_AdId",
                table: "Comments",
                newName: "IX_Comments_AddId");

            migrationBuilder.CreateTable(
                name: "Adds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adds_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adds_AuthorId",
                table: "Adds",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Adds_IsDeleted",
                table: "Adds",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Adds_AddId",
                table: "Comments",
                column: "AddId",
                principalTable: "Adds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Adds_AddForeignKey",
                table: "Pets",
                column: "AddForeignKey",
                principalTable: "Adds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_Adds_AddId",
                table: "Statistics",
                column: "AddId",
                principalTable: "Adds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
