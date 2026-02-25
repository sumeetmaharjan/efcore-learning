using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovies.Migrations
{
    /// <inheritdoc />
    public partial class GenreAuditable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Genres",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Genres",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-0da5-08daaa06a9ca"),
                columns: new[] { "CreatedBy", "ModifiedBy" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-cdff-08daaa06a9cb"),
                columns: new[] { "CreatedBy", "ModifiedBy" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-dd58-08daaa06a9cb"),
                columns: new[] { "CreatedBy", "ModifiedBy" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-e0dd-08daaa06a9cb"),
                columns: new[] { "CreatedBy", "ModifiedBy" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-e3c4-08daaa06a9cb"),
                columns: new[] { "CreatedBy", "ModifiedBy" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Genres");
        }
    }
}
