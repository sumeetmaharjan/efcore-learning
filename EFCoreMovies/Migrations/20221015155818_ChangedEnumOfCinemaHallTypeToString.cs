using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovies.Migrations
{
    public partial class ChangedEnumOfCinemaHallTypeToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CinemaHallType",
                table: "CinemaHalls",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "TwoDimension",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-2621-08daaa0901d0"),
                column: "CinemaHallType",
                value: "TwoDimension");

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-697e-08daaa0901d0"),
                column: "CinemaHallType",
                value: "ThreeDimension");

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-7570-08daaa0901d0"),
                column: "CinemaHallType",
                value: "ThreeDimension");

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-7b22-08daaa0901d0"),
                column: "CinemaHallType",
                value: "Cxc");

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-8070-08daaa0901d0"),
                column: "CinemaHallType",
                value: "TwoDimension");

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-860c-08daaa0901d0"),
                column: "CinemaHallType",
                value: "ThreeDimension");

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-8b7e-08daaa0901d0"),
                column: "CinemaHallType",
                value: "Cxc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CinemaHallType",
                table: "CinemaHalls",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldDefaultValue: "TwoDimension");

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-2621-08daaa0901d0"),
                column: "CinemaHallType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-697e-08daaa0901d0"),
                column: "CinemaHallType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-7570-08daaa0901d0"),
                column: "CinemaHallType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-7b22-08daaa0901d0"),
                column: "CinemaHallType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-8070-08daaa0901d0"),
                column: "CinemaHallType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-860c-08daaa0901d0"),
                column: "CinemaHallType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-8b7e-08daaa0901d0"),
                column: "CinemaHallType",
                value: 3);
        }
    }
}
