using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreCrud.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collectible_Manufacturer_ManufacturerID",
                table: "Collectible");

            migrationBuilder.DropColumn(
                name: "PublisherID",
                table: "Collectible");

            migrationBuilder.AlterColumn<int>(
                name: "ManufacturerID",
                table: "Collectible",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Collectible_Manufacturer_ManufacturerID",
                table: "Collectible",
                column: "ManufacturerID",
                principalTable: "Manufacturer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collectible_Manufacturer_ManufacturerID",
                table: "Collectible");

            migrationBuilder.AlterColumn<int>(
                name: "ManufacturerID",
                table: "Collectible",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PublisherID",
                table: "Collectible",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Collectible_Manufacturer_ManufacturerID",
                table: "Collectible",
                column: "ManufacturerID",
                principalTable: "Manufacturer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
