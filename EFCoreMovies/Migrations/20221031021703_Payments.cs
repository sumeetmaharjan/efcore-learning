using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovies.Migrations
{
    public partial class Payments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "date", nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    Last4Digit = table.Column<string>(type: "char(4)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "Id", "Amount", "Last4Digit", "PaymentDate", "PaymentType" },
                values: new object[,]
                {
                    { new Guid("4fb60000-a64a-9828-363b-08dabae55e02"), 852m, "1234", new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { new Guid("4fb60000-a64a-9828-7a5c-08dabae55e02"), 456m, "3214", new DateTime(2022, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "Id", "Amount", "Email", "PaymentDate", "PaymentType" },
                values: new object[,]
                {
                    { new Guid("4fb60000-a64a-9828-453c-08dabae50089"), 213m, "test@hotmail.com", new DateTime(2022, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("4fb60000-a64a-9828-e2c2-08dabae50088"), 123m, "test@gmail.com", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");
        }
    }
}
