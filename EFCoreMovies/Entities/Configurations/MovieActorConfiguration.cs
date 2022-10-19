using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Entities.Configurations
{
    public class MovieActorConfiguration : IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> builder)
        {
            builder.HasKey(p => new { p.MovieId, p.ActorId }); // Composite Primary Key 
            builder.Property(p => p.Order).HasMaxLength(150);

            // Many to Many Relationship when there is Intermediate Entity (Mapping Table/ Non Skip). Created by Combining 2 One to One Relationship
            builder.HasOne(p => p.Actor).WithMany(p => p.MovieActors).HasForeignKey(p => p.ActorId); // One to Many

            builder.HasOne(p => p.Movie).WithMany(p => p.MovieActors).HasForeignKey(p => p.MovieId); // One to Many

            builder.HasData(
                KeanuRevesMatrix(),
                ChrisEvansAvengers(),
                RobertDJrAvengers(),
                ScarlettJohanssonAvengers(),
                TomHollandFFH(),
                TomHollandNWH(),
                SamuelJacksonFFH()
            );
        }

        internal static MovieActor KeanuRevesMatrix()
        {
            return new MovieActor
            {
                ActorId = ActorConfiguration.KeanuReeves().Id,
                MovieId = MovieConfiguration.Matrix().Id,
                Order = 1,
                Character = "Neo"
            };
        }

        internal static MovieActor ChrisEvansAvengers()
        {
            return new MovieActor
            {
                ActorId = ActorConfiguration.ChrisEvans().Id,
                MovieId = MovieConfiguration.Avengers().Id,
                Order = 1,
                Character = "Captain America"
            };
        }

        internal static MovieActor RobertDJrAvengers()
        {
            return new MovieActor
            {
                ActorId = ActorConfiguration.RobertDowneyJr().Id,
                MovieId = MovieConfiguration.Avengers().Id,
                Order = 2,
                Character = "Iron Man"
            };
        }

        internal static MovieActor ScarlettJohanssonAvengers()
        {
            return new MovieActor
            {
                ActorId = ActorConfiguration.ScarlettJohansson().Id,
                MovieId = MovieConfiguration.Avengers().Id,
                Order = 3,
                Character = "Black Widow"
            };
        }

        internal static MovieActor TomHollandFFH()
        {
            return new MovieActor
            {
                ActorId = ActorConfiguration.TomHolland().Id,
                MovieId = MovieConfiguration.SpidermanFfh().Id,
                Order = 2,
                Character = "Peter Parker"
            };
        }

        internal static MovieActor TomHollandNWH()
        {
            return new MovieActor
            {
                ActorId = ActorConfiguration.TomHolland().Id,
                MovieId = MovieConfiguration.SpidermanNwh().Id,
                Order = 1,
                Character = "Peter Parker"
            };
        }

        internal static MovieActor SamuelJacksonFFH()
        {
            return new MovieActor
            {
                ActorId = ActorConfiguration.SamuelJackson().Id,
                MovieId = MovieConfiguration.SpidermanFfh().Id,
                Order = 2,
                Character = "Nick Fury"
            };
        }
    }
}