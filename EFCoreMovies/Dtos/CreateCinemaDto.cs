namespace EFCoreMovies.Dtos
{
    public class CreateCinemaDto
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public CreateCinemaOfferDto CinemaOffer { get; set; }
        public CreateCinemaHallDto[] CinemaHalls { get; set; }
    }
}
