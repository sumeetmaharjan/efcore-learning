using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovies.Migrations
{
    public partial class AddedMessageAndPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Persons_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Persons_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("4fb60000-a64a-9828-06dd-08dab177526d"), "Sumitra" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("4fb60000-a64a-9828-5ee7-08dab177526c"), "Mahendra" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Content", "ReceiverId", "SenderId" },
                values: new object[,]
                {
                    { new Guid("4fb60000-a64a-9828-0d98-08dab1786aeb"), "Hello, Sumitra", new Guid("4fb60000-a64a-9828-06dd-08dab177526d"), new Guid("4fb60000-a64a-9828-5ee7-08dab177526c") },
                    { new Guid("4fb60000-a64a-9828-1eb5-08dab1786aeb"), "K cha? Sanchai Chau?", new Guid("4fb60000-a64a-9828-06dd-08dab177526d"), new Guid("4fb60000-a64a-9828-5ee7-08dab177526c") },
                    { new Guid("4fb60000-a64a-9828-24a2-08dab1786aeb"), "Umm Thik cha. Hajur Ko?", new Guid("4fb60000-a64a-9828-5ee7-08dab177526c"), new Guid("4fb60000-a64a-9828-06dd-08dab177526d") },
                    { new Guid("4fb60000-a64a-9828-cda3-08dab1786aea"), "Hi, Mahendra", new Guid("4fb60000-a64a-9828-5ee7-08dab177526c"), new Guid("4fb60000-a64a-9828-06dd-08dab177526d") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
