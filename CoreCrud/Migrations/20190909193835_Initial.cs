using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreCrud.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PublisherName = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Collectible",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    Forsale = table.Column<bool>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Author = table.Column<string>(nullable: true),
                    PublisherID = table.Column<int>(nullable: false),
                    ManufacturerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collectible", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Collectible_Manufacturer_ManufacturerID",
                        column: x => x.ManufacturerID,
                        principalTable: "Manufacturer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collectible_ManufacturerID",
                table: "Collectible",
                column: "ManufacturerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Collectible");

            migrationBuilder.DropTable(
                name: "Manufacturer");
        }
    }
}
