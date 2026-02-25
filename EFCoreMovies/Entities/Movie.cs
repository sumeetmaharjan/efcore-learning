using System;
using System.Collections.Generic;

namespace EFCoreMovies.Entities
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool InCinema { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PosterUrl { get; set; }
        public List<Genre> Genres { get; set; } // Skip Style Many-Many RelationShip Look at Genre
        public List<CinemaHall> CinemaHalls { get; set; } // Skip Style Many-Many RelationShip Look at CinemaHall
        public List<MovieActor> MovieActors { get; set; } // None Skip Style Many-Many RelationShip Look at MovieActor
    }
}
// Movie has Many to Many Relationship with Genre.