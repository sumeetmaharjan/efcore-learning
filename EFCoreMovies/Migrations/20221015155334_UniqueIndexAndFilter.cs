using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovies.Migrations
{
    public partial class UniqueIndexAndFilter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-0da5-08daaa06a9ca"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-cdff-08daaa06a9cb"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-dd58-08daaa06a9cb"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-e0dd-08daaa06a9cb"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-e3c4-08daaa06a9cb"));

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name",
                unique: true,
                filter: "IsDeleted = 'false'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Genres_Name",
                table: "Genres");

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("4fb60000-a64a-9828-0da5-08daaa06a9ca"), false, "Action" },
                    { new Guid("4fb60000-a64a-9828-cdff-08daaa06a9cb"), false, "Animation" },
                    { new Guid("4fb60000-a64a-9828-dd58-08daaa06a9cb"), false, "Comedy" },
                    { new Guid("4fb60000-a64a-9828-e0dd-08daaa06a9cb"), false, "Science Friction" },
                    { new Guid("4fb60000-a64a-9828-e3c4-08daaa06a9cb"), false, "Drama" }
                });
        }
    }
}
