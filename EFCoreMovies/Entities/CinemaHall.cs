using System;
using System.Collections.Generic;
using EFCoreMovies.Entities.Enumerations;

namespace EFCoreMovies.Entities
{
    public class CinemaHall
    {
        public Guid Id { get; set; }
        public CinemaHallType CinemaHallType { get; set; }
        public decimal Cost { get; set; }
        public Guid? CinemaId { get; set; }
        public Currency Currency { get; set; }
        public Cinema Cinema { get; set; } // <= Navigation Property
        public ICollection<Movie> Movies { get; set; } // Skip Style Many-Many RelationShip Look at Movie
    }
}