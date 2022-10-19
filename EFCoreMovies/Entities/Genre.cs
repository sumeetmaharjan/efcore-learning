namespace EFCoreMovies.Entities
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Movie> Movies { get; set; } // Skip Style Many-Many RelationShip Look at Movie
        // This Entity has Shadow Property. Which is available in Table but not in Entity. This one has DateCreated as Shadow Property. See GenreConfiguration CreatedDate Property
    }
}

// Genre has Many to Many Relationship with Movie. 