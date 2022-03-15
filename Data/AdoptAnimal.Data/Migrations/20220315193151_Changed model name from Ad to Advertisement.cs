using Microsoft.EntityFrameworkCore.Migrations;

namespace AdoptAnimal.Data.Migrations
{
    public partial class ChangedmodelnamefromAdtoAdvertisement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "AdId",
                table: "Statistics",
                newName: "AdvertisementId");

            migrationBuilder.RenameIndex(
                name: "IX_Statistics_AdId",
                table: "Statistics",
                newName: "IX_Statistics_AdvertisementId");

            migrationBuilder.RenameColumn(
                name: "AdForeignKey",
                table: "Pets",
                newName: "AdvertisementForeignKey");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_AdForeignKey",
                table: "Pets",
                newName: "IX_Pets_AdvertisementForeignKey");

            migrationBuilder.RenameColumn(
                name: "AdId",
                table: "Comments",
                newName: "AdvertisementId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_AdId",
                table: "Comments",
                newName: "IX_Comments_AdvertisementId");

            migrationBuilder.AddColumn<int>(
                name: "PetId",
                table: "Ads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Ads_AdvertisementId",
                table: "Comments",
                column: "AdvertisementId",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Ads_AdvertisementForeignKey",
                table: "Pets",
                column: "AdvertisementForeignKey",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Ads_AdvertisementId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Ads_AdvertisementForeignKey",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Statistics_Ads_AdvertisementId",
                table: "Statistics");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "Ads");

            migrationBuilder.RenameColumn(
                name: "AdvertisementId",
                table: "Statistics",
                newName: "AdId");

            migrationBuilder.RenameIndex(
                name: "IX_Statistics_AdvertisementId",
                table: "Statistics",
                newName: "IX_Statistics_AdId");

            migrationBuilder.RenameColumn(
                name: "AdvertisementForeignKey",
                table: "Pets",
                newName: "AdForeignKey");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_AdvertisementForeignKey",
                table: "Pets",
                newName: "IX_Pets_AdForeignKey");

            migrationBuilder.RenameColumn(
                name: "AdvertisementId",
                table: "Comments",
                newName: "AdId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_AdvertisementId",
                table: "Comments",
                newName: "IX_Comments_AdId");

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
    }
}
