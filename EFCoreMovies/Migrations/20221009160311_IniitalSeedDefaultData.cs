using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace EFCoreMovies.Migrations
{
    public partial class IniitalSeedDefaultData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Biography",
                table: "Actors",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Biography", "DateOfBirth", "Name" },
                values: new object[,]
                {
                    { new Guid("4fb60000-a64a-9828-0235-08daaa06a9cc"), null, new DateTime(1964, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Keanu Reeves" },
                    { new Guid("4fb60000-a64a-9828-ea48-08daaa06a9cb"), "Thomas Stanley Holland (born 1 June 1996) is an English actor. He is recipient of several accolades, including the 2017 BAFTA Rising Star Award. Holland began his acting career as a child actor on the West End stage in Billy Elliot the Musical at the Victoria Palace Theater in 2008, playing a supporting part", new DateTime(1996, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tom Holland" },
                    { new Guid("4fb60000-a64a-9828-f090-08daaa06a9cb"), "Samuel Leroy Jackson (born December 21, 1948) is an American actor and producer. One of the most widely recognized actors of his generation, the films in which he has appeared have collectively grossed over $27 billion worldwide, making him the highest-grossing actor of all time (excluding cameo appearances and voice roles).", new DateTime(1948, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samuel L. Jackson" },
                    { new Guid("4fb60000-a64a-9828-f42a-08daaa06a9cb"), "Robert John Downey Jr. (born April 4, 1965) is an American actor and producer. His career has been characterized by critical and popular success in his youth, followed by a period of substance abuse and legal troubles, before a resurgence of commercial success later in his career.", new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Downey Jr." },
                    { new Guid("4fb60000-a64a-9828-f6bf-08daaa06a9cb"), null, new DateTime(1981, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chris Evans" },
                    { new Guid("4fb60000-a64a-9828-f97f-08daaa06a9cb"), null, new DateTime(1972, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dwayne Johnson" },
                    { new Guid("4fb60000-a64a-9828-fc0c-08daaa06a9cb"), null, new DateTime(2000, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Auli'i Cravalho" },
                    { new Guid("4fb60000-a64a-9828-ff1f-08daaa06a9cb"), null, new DateTime(1984, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scarlett Johansson" }
                });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("4fb60000-a64a-9828-04f7-08daaa06a9cc"), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (27.6772126 85.317018)"), "Labim Mall" },
                    { new Guid("4fb60000-a64a-9828-07a5-08daaa06a9cc"), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (27.6992707 85.3084962)"), "Civil Mall" },
                    { new Guid("4fb60000-a64a-9828-09ed-08daaa06a9cc"), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (27.6751519 85.3968551)"), "Bhaktapur Mall" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4fb60000-a64a-9828-0da5-08daaa06a9ca"), "Action" },
                    { new Guid("4fb60000-a64a-9828-cdff-08daaa06a9cb"), "Animation" },
                    { new Guid("4fb60000-a64a-9828-dd58-08daaa06a9cb"), "Comedy" },
                    { new Guid("4fb60000-a64a-9828-e0dd-08daaa06a9cb"), "Science Friction" },
                    { new Guid("4fb60000-a64a-9828-e3c4-08daaa06a9cb"), "Drama" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "InCinema", "PosterUrl", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("4fb60000-a64a-9828-a079-08daaa0857ff"), false, "https://upload.wikimedia.org/wikipedia/en/9/98/Coco_%282017_film%29_poster.jpg", new DateTime(2017, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coco" },
                    { new Guid("4fb60000-a64a-9828-e5a1-08daaa0857ff"), false, "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg", new DateTime(2022, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spider-Man: No Way Home" },
                    { new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff"), true, "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg", new DateTime(2019, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spider-Man: Far From Home" },
                    { new Guid("4fb60000-a64a-9828-f435-08daaa0857ff"), true, "https://upload.wikimedia.org/wikipedia/en/5/50/The_Matrix_Resurrections.jpg", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" },
                    { new Guid("4fb60000-a64a-9828-f914-08daaa0857ff"), false, "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg", new DateTime(2012, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avengers" }
                });

            migrationBuilder.InsertData(
                table: "CinemaHalls",
                columns: new[] { "Id", "CinemaHallType", "CinemaId", "Cost" },
                values: new object[,]
                {
                    { new Guid("4fb60000-a64a-9828-2621-08daaa0901d0"), 1, new Guid("4fb60000-a64a-9828-04f7-08daaa06a9cc"), 150m },
                    { new Guid("4fb60000-a64a-9828-697e-08daaa0901d0"), 2, new Guid("4fb60000-a64a-9828-04f7-08daaa06a9cc"), 250m },
                    { new Guid("4fb60000-a64a-9828-7570-08daaa0901d0"), 2, new Guid("4fb60000-a64a-9828-09ed-08daaa06a9cc"), 250m },
                    { new Guid("4fb60000-a64a-9828-7b22-08daaa0901d0"), 3, new Guid("4fb60000-a64a-9828-09ed-08daaa06a9cc"), 500m },
                    { new Guid("4fb60000-a64a-9828-8070-08daaa0901d0"), 1, new Guid("4fb60000-a64a-9828-07a5-08daaa06a9cc"), 150m },
                    { new Guid("4fb60000-a64a-9828-860c-08daaa0901d0"), 2, new Guid("4fb60000-a64a-9828-07a5-08daaa06a9cc"), 250m },
                    { new Guid("4fb60000-a64a-9828-8b7e-08daaa0901d0"), 3, new Guid("4fb60000-a64a-9828-07a5-08daaa06a9cc"), 550m }
                });

            migrationBuilder.InsertData(
                table: "CinemaOffers",
                columns: new[] { "Id", "Begin", "CinemaId", "DecimalPercentage", "End" },
                values: new object[,]
                {
                    { new Guid("4fb60000-a64a-9828-d903-08daaa073920"), new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4fb60000-a64a-9828-04f7-08daaa06a9cc"), 10m, new DateTime(2022, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4fb60000-a64a-9828-dc4a-08daaa073920"), new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4fb60000-a64a-9828-09ed-08daaa06a9cc"), 13m, new DateTime(2022, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "GenreMovie",
                columns: new[] { "GenresId", "MoviesId" },
                values: new object[,]
                {
                    { new Guid("4fb60000-a64a-9828-0da5-08daaa06a9ca"), new Guid("4fb60000-a64a-9828-e5a1-08daaa0857ff") },
                    { new Guid("4fb60000-a64a-9828-0da5-08daaa06a9ca"), new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff") },
                    { new Guid("4fb60000-a64a-9828-0da5-08daaa06a9ca"), new Guid("4fb60000-a64a-9828-f914-08daaa0857ff") },
                    { new Guid("4fb60000-a64a-9828-cdff-08daaa06a9cb"), new Guid("4fb60000-a64a-9828-a079-08daaa0857ff") },
                    { new Guid("4fb60000-a64a-9828-dd58-08daaa06a9cb"), new Guid("4fb60000-a64a-9828-e5a1-08daaa0857ff") },
                    { new Guid("4fb60000-a64a-9828-dd58-08daaa06a9cb"), new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff") },
                    { new Guid("4fb60000-a64a-9828-e0dd-08daaa06a9cb"), new Guid("4fb60000-a64a-9828-e5a1-08daaa0857ff") },
                    { new Guid("4fb60000-a64a-9828-e0dd-08daaa06a9cb"), new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff") },
                    { new Guid("4fb60000-a64a-9828-e0dd-08daaa06a9cb"), new Guid("4fb60000-a64a-9828-f914-08daaa0857ff") }
                });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "ActorId", "MovieId", "Character", "Order" },
                values: new object[,]
                {
                    { new Guid("4fb60000-a64a-9828-ea48-08daaa06a9cb"), new Guid("4fb60000-a64a-9828-e5a1-08daaa0857ff"), "Peter Parker", 1 },
                    { new Guid("4fb60000-a64a-9828-ea48-08daaa06a9cb"), new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff"), "Peter Parker", 2 },
                    { new Guid("4fb60000-a64a-9828-f090-08daaa06a9cb"), new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff"), "Nick Fury", 2 },
                    { new Guid("4fb60000-a64a-9828-0235-08daaa06a9cc"), new Guid("4fb60000-a64a-9828-f435-08daaa0857ff"), "Neo", 1 },
                    { new Guid("4fb60000-a64a-9828-f42a-08daaa06a9cb"), new Guid("4fb60000-a64a-9828-f914-08daaa0857ff"), "Iron Man", 2 },
                    { new Guid("4fb60000-a64a-9828-f6bf-08daaa06a9cb"), new Guid("4fb60000-a64a-9828-f914-08daaa0857ff"), "Captain America", 1 },
                    { new Guid("4fb60000-a64a-9828-ff1f-08daaa06a9cb"), new Guid("4fb60000-a64a-9828-f914-08daaa0857ff"), "Black Widow", 3 }
                });

            migrationBuilder.InsertData(
                table: "CinemaHallMovie",
                columns: new[] { "CinemaHallsId", "MoviesId" },
                values: new object[,]
                {
                    { new Guid("4fb60000-a64a-9828-2621-08daaa0901d0"), new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff") },
                    { new Guid("4fb60000-a64a-9828-697e-08daaa0901d0"), new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff") },
                    { new Guid("4fb60000-a64a-9828-697e-08daaa0901d0"), new Guid("4fb60000-a64a-9828-f435-08daaa0857ff") },
                    { new Guid("4fb60000-a64a-9828-7570-08daaa0901d0"), new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff") },
                    { new Guid("4fb60000-a64a-9828-7570-08daaa0901d0"), new Guid("4fb60000-a64a-9828-f435-08daaa0857ff") },
                    { new Guid("4fb60000-a64a-9828-7b22-08daaa0901d0"), new Guid("4fb60000-a64a-9828-f435-08daaa0857ff") },
                    { new Guid("4fb60000-a64a-9828-8070-08daaa0901d0"), new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff") },
                    { new Guid("4fb60000-a64a-9828-860c-08daaa0901d0"), new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff") },
                    { new Guid("4fb60000-a64a-9828-860c-08daaa0901d0"), new Guid("4fb60000-a64a-9828-f435-08daaa0857ff") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-f97f-08daaa06a9cb"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-fc0c-08daaa06a9cb"));

            migrationBuilder.DeleteData(
                table: "CinemaHallMovie",
                keyColumns: new[] { "CinemaHallsId", "MoviesId" },
                keyValues: new object[] { new Guid("4fb60000-a64a-9828-2621-08daaa0901d0"), new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff") });

            migrationBuilder.DeleteData(
                table: "CinemaHallMovie",
                keyColumns: new[] { "CinemaHallsId", "MoviesId" },
                keyValues: new object[] { new Guid("4fb60000-a64a-9828-697e-08daaa0901d0"), new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff") });

            migrationBuilder.DeleteData(
                table: "CinemaHallMovie",
                keyColumns: new[] { "CinemaHallsId", "MoviesId" },
                keyValues: new object[] { new Guid("4fb60000-a64a-9828-697e-08daaa0901d0"), new Guid("4fb60000-a64a-9828-f435-08daaa0857ff") });

            migrationBuilder.DeleteData(
                table: "CinemaHallMovie",
                keyColumns: new[] { "CinemaHallsId", "MoviesId" },
                keyValues: new object[] { new Guid("4fb60000-a64a-9828-7570-08daaa0901d0"), new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff") });

            migrationBuilder.DeleteData(
                table: "CinemaHallMovie",
                keyColumns: new[] { "CinemaHallsId", "MoviesId" },
                keyValues: new object[] { new Guid("4fb60000-a64a-9828-7570-08daaa0901d0"), new Guid("4fb60000-a64a-9828-f435-08daaa0857ff") });

            migrationBuilder.DeleteData(
                table: "CinemaHallMovie",
                keyColumns: new[] { "CinemaHallsId", "MoviesId" },
                keyValues: new object[] { new Guid("4fb60000-a64a-9828-7b22-08daaa0901d0"), new Guid("4fb60000-a64a-9828-f435-08daaa0857ff") });

            migrationBuilder.DeleteData(
                table: "CinemaHallMovie",
                keyColumns: new[] { "CinemaHallsId", "MoviesId" },
                keyValues: new object[] { new Guid("4fb60000-a64a-9828-8070-08daaa0901d0"), new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff") });

            migrationBuilder.DeleteData(
                table: "CinemaHallMovie",
                keyColumns: new[] { "CinemaHallsId", "MoviesId" },
                keyValues: new object[] { new Guid("4fb60000-a64a-9828-860c-08daaa0901d0"), new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff") });

            migrationBuilder.DeleteData(
                table: "CinemaHallMovie",
                keyColumns: new[] { "CinemaHallsId", "MoviesId" },
                keyValues: new object[] { new Guid("4fb60000-a64a-9828-860c-08daaa0901d0"), new Guid("4fb60000-a64a-9828-f435-08daaa0857ff") });

            migrationBuilder.DeleteData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-8b7e-08daaa0901d0"));

            migrationBuilder.DeleteData(
                table: "CinemaOffers",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-d903-08daaa073920"));

            migrationBuilder.DeleteData(
                table: "CinemaOffers",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-dc4a-08daaa073920"));

            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresId", "MoviesId" },
                keyValues: new object[] { new Guid("4fb60000-a64a-9828-0da5-08daaa06a9ca"), new Guid("4fb60000-a64a-9828-e5a1-08daaa0857ff") });

            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresId", "MoviesId" },
                keyValues: new object[] { new Guid("4fb60000-a64a-9828-0da5-08daaa06a9ca"), new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff") });

            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresId", "MoviesId" },
                keyValues: new object[] { new Guid("4fb60000-a64a-9828-0da5-08daaa06a9ca"), new Guid("4fb60000-a64a-9828-f914-08daaa0857ff") });

            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresId", "MoviesId" },
                keyValues: new object[] { new Guid("4fb60000-a64a-9828-cdff-08daaa06a9cb"), new Guid("4fb60000-a64a-9828-a079-08daaa0857ff") });

            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresId", "MoviesId" },
                keyValues: new object[] { new Guid("4fb60000-a64a-9828-dd58-08daaa06a9cb"), new Guid("4fb60000-a64a-9828-e5a1-08daaa0857ff") });

            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresId", "MoviesId" },
                keyValues: new object[] { new Guid("4fb60000-a64a-9828-dd58-08daaa06a9cb"), new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff") });

            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresId", "MoviesId" },
                keyValues: new object[] { new Guid("4fb60000-a64a-9828-e0dd-08daaa06a9cb"), new Guid("4fb60000-a64a-9828-e5a1-08daaa0857ff") });

            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresId", "MoviesId" },
                keyValues: new object[] { new Guid("4fb60000-a64a-9828-e0dd-08daaa06a9cb"), new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff") });

            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresId", "MoviesId" },
                keyValues: new object[] { new Guid("4fb60000-a64a-9828-e0dd-08daaa06a9cb"), new Guid("4fb60000-a64a-9828-f914-08daaa0857ff") });

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-e3c4-08daaa06a9cb"));

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("4fb60000-a64a-9828-ea48-08daaa06a9cb"), new Guid("4fb60000-a64a-9828-e5a1-08daaa0857ff") });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("4fb60000-a64a-9828-ea48-08daaa06a9cb"), new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff") });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("4fb60000-a64a-9828-f090-08daaa06a9cb"), new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff") });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("4fb60000-a64a-9828-0235-08daaa06a9cc"), new Guid("4fb60000-a64a-9828-f435-08daaa0857ff") });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("4fb60000-a64a-9828-f42a-08daaa06a9cb"), new Guid("4fb60000-a64a-9828-f914-08daaa0857ff") });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("4fb60000-a64a-9828-f6bf-08daaa06a9cb"), new Guid("4fb60000-a64a-9828-f914-08daaa0857ff") });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("4fb60000-a64a-9828-ff1f-08daaa06a9cb"), new Guid("4fb60000-a64a-9828-f914-08daaa0857ff") });

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-0235-08daaa06a9cc"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-ea48-08daaa06a9cb"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-f090-08daaa06a9cb"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-f42a-08daaa06a9cb"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-f6bf-08daaa06a9cb"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-ff1f-08daaa06a9cb"));

            migrationBuilder.DeleteData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-2621-08daaa0901d0"));

            migrationBuilder.DeleteData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-697e-08daaa0901d0"));

            migrationBuilder.DeleteData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-7570-08daaa0901d0"));

            migrationBuilder.DeleteData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-7b22-08daaa0901d0"));

            migrationBuilder.DeleteData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-8070-08daaa0901d0"));

            migrationBuilder.DeleteData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-860c-08daaa0901d0"));

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
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-a079-08daaa0857ff"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-e5a1-08daaa0857ff"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-f435-08daaa0857ff"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-f914-08daaa0857ff"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-04f7-08daaa06a9cc"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-07a5-08daaa06a9cc"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("4fb60000-a64a-9828-09ed-08daaa06a9cc"));

            migrationBuilder.AlterColumn<string>(
                name: "Biography",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);
        }
    }
}
