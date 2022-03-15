using Microsoft.EntityFrameworkCore.Migrations;

namespace AdoptAnimal.Data.Migrations
{
    public partial class ChangedrelationbetweenPetandAdvertisement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Ads_AdvertisementForeignKey",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_AdvertisementForeignKey",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "Ads");

            migrationBuilder.AddColumn<int>(
                name: "AdvertisementId",
                table: "Pets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_AdvertisementId",
                table: "Pets",
                column: "AdvertisementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Ads_AdvertisementId",
                table: "Pets",
                column: "AdvertisementId",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Ads_AdvertisementId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_AdvertisementId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "AdvertisementId",
                table: "Pets");

            migrationBuilder.AddColumn<int>(
                name: "PetId",
                table: "Ads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_AdvertisementForeignKey",
                table: "Pets",
                column: "AdvertisementForeignKey",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Ads_AdvertisementForeignKey",
                table: "Pets",
                column: "AdvertisementForeignKey",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
