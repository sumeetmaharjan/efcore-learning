namespace EFCoreMovies.Dtos
{
    public class MovieFilterDto
    {
        public string? Title { get; set; }
        public Guid? GenreId { get; set; }
        public bool? InCinema { get; set; }
        public bool? UpCommingRelease { get; set; }
    }
}
