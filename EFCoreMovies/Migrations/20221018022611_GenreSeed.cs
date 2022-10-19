using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovies.Migrations
{
    public partial class GenreSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
