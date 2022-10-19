namespace EFCoreMovies.Entities
{
    public class MovieActor
    {
        public Guid MovieId { get; set; }
        public Guid ActorId { get; set; }
        public string Character { get; set; }
        public int Order { get; set; }
        public Movie Movie { get; set; } // None Skip Style Many-Many RelationShip Look at Movie
        public Actor Actor { get; set; } // None Skip Style Many-Many RelationShip Look at Actor

    }
}

// MovieActor has composite key made from MovieId and ActorId which is configured using FluentAPI in MovieActorConfiguration 