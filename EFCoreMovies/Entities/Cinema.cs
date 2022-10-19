using NetTopologySuite.Geometries;

namespace EFCoreMovies.Entities
{
    
    public class Cinema
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Point Location { get; set; }
        public CinemaOffer CinemaOffer { get; set; } // <= this is navigation property
        public ICollection<CinemaHall> CinemaHalls { get; set; }
    }
}

// Cinema has One to One Relationship with Cinema Offer. Cinema can only have 1 Offer at a time and an Offer can only belong to 1 Cinema.
// Cinema has single CinemaOffer and CinemaOffer has single CinemaId. 