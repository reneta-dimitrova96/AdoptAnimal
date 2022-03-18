using Microsoft.EntityFrameworkCore.Migrations;

namespace AdoptAnimal.Data.Migrations
{
    public partial class Changeddbsetnametoadvertimesements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_AspNetUsers_AuthorId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Ads_AdvertisementId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Ads_AdvertisementId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Statistics_Ads_AdvertisementId",
                table: "Statistics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ads",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "AdvertisementForeignKey",
                table: "Pets");

            migrationBuilder.RenameTable(
                name: "Ads",
                newName: "Advertisements");

            migrationBuilder.RenameIndex(
                name: "IX_Ads_IsDeleted",
                table: "Advertisements",
                newName: "IX_Advertisements_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Ads_AuthorId",
                table: "Advertisements",
                newName: "IX_Advertisements_AuthorId");

            migrationBuilder.AlterColumn<int>(
                name: "AdvertisementId",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Advertisements",
                table: "Advertisements",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_AspNetUsers_AuthorId",
                table: "Advertisements",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Advertisements_AdvertisementId",
                table: "Comments",
                column: "AdvertisementId",
                principalTable: "Advertisements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Advertisements_AdvertisementId",
                table: "Pets",
                column: "AdvertisementId",
                principalTable: "Advertisements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_Advertisements_AdvertisementId",
                table: "Statistics",
                column: "AdvertisementId",
                principalTable: "Advertisements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_AspNetUsers_AuthorId",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Advertisements_AdvertisementId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Advertisements_AdvertisementId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Statistics_Advertisements_AdvertisementId",
                table: "Statistics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Advertisements",
                table: "Advertisements");

            migrationBuilder.RenameTable(
                name: "Advertisements",
                newName: "Ads");

            migrationBuilder.RenameIndex(
                name: "IX_Advertisements_IsDeleted",
                table: "Ads",
                newName: "IX_Ads_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Advertisements_AuthorId",
                table: "Ads",
                newName: "IX_Ads_AuthorId");

            migrationBuilder.AlterColumn<int>(
                name: "AdvertisementId",
                table: "Pets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AdvertisementForeignKey",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ads",
                table: "Ads",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_AspNetUsers_AuthorId",
                table: "Ads",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Ads_AdvertisementId",
                table: "Comments",
                column: "AdvertisementId",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Ads_AdvertisementId",
                table: "Pets",
                column: "AdvertisementId",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_Ads_AdvertisementId",
                table: "Statistics",
                column: "AdvertisementId",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
