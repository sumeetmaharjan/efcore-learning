using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreMovies.Migrations
{
    /// <inheritdoc />
    public partial class Products : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Merchandising",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Volume = table.Column<double>(type: "float", nullable: false),
                    IsClothing = table.Column<bool>(type: "bit", nullable: false),
                    IsCollectable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchandising", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Merchandising_Products_Id",
                        column: x => x.Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentableMovies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentableMovies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentableMovies_Products_Id",
                        column: x => x.Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("0c120000-de89-ae50-2016-08dbee085f9b"), "Spider-Man", 5.99m },
                    { new Guid("0c120000-de89-ae50-6d3c-08dbee085f9c"), "Naruto T-Shirt", 11.99m }
                });

            migrationBuilder.InsertData(
                table: "Merchandising",
                columns: new[] { "Id", "Available", "IsClothing", "IsCollectable", "Volume", "Weight" },
                values: new object[] { new Guid("0c120000-de89-ae50-6d3c-08dbee085f9c"), true, true, false, 1.0, 1.0 });

            migrationBuilder.InsertData(
                table: "RentableMovies",
                columns: new[] { "Id", "MovieId" },
                values: new object[] { new Guid("0c120000-de89-ae50-2016-08dbee085f9b"), new Guid("4fb60000-a64a-9828-e5a1-08daaa0857ff") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Merchandising");

            migrationBuilder.DropTable(
                name: "RentableMovies");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
