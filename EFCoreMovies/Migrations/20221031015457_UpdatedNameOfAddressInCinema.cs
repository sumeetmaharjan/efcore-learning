using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovies.Migrations
{
    public partial class UpdatedNameOfAddressInCinema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_State",
                table: "Cinemas",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "Address_Country",
                table: "Cinemas",
                newName: "Country");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "State",
                table: "Cinemas",
                newName: "Address_State");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Cinemas",
                newName: "Address_Country");
        }
    }
}
