using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovies.Migrations
{
    public partial class ViewMovieCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                Create View dbo.MoviesWithCounts 
                As
                SELECT Id, Title,
                    (Select count(*) FROM GenreMovie WHERE MoviesId = movies.Id) as AmountGenre,
                    (select count(distinct moviesId) FROM CinemaHallMovie
                        INNER JOIN CinemaHalls
                        ON CinemaHalls.Id = CinemaHallMovie.CinemaHallsId
                        WHERE MoviesId = movies.Id) AS AmountCinemas,
                    (Select count(*) from MovieActors WHERE MovieId = movies.Id) as AmountActor
                From Movies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Drop View dbo.MoviesWithCounts");
        }
    }
}
