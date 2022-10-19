namespace EFCoreMovies.Dtos
{
    public class CreateMovieDto
    {
        public string Title { get; set; }
        public bool InCinema { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Guid> GenreIds { get; set; }
        public List<Guid> CinemaHallIds { get; set; }
        public List<CreateMovieActorDto> MovieActors { get; set; }
    }
}
