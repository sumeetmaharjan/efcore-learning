using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Entities.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>

    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(150).IsRequired();
            //builder.Property(x => x.ReleaseDate).HasColumnType("date"); // Override by configuration in ApplicationDbContext OnModelCreating
            builder.Property(x => x.PosterUrl).HasMaxLength(500).IsUnicode(false);

            // Many to Many Relationship for No Intermediate Entity (Skip Navigation)
            builder.HasMany(p => p.Genres)
                .WithMany(p => p.Movies); // Read as Movies has Many genre and genre has many Movies
            // .UsingEntity(j => j.ToTable("GenresMovies").HasData(new { MovieId=Guid.Parse(),GenreId=Guid.Parse()})); // Do this if you want to seed data to the table from FluentAPI
            builder.HasData(
                Avengers(),
                SpidermanNwh(),
                Coco(),
                SpidermanFfh(),
                Matrix()
            );
        }

        internal static Movie Avengers()
        {
            return new Movie
            {
                Id = Guid.Parse("4fb60000-a64a-9828-f914-08daaa0857ff"),
                Title = "Avengers",
                InCinema = false,
                ReleaseDate = new DateTime(2012, 4, 11),
                PosterUrl = "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg"
            };
        }

        internal static Movie Coco()
        {
            return new Movie
            {
                Id = Guid.Parse("4fb60000-a64a-9828-a079-08daaa0857ff"),
                Title = "Coco",
                InCinema = false,
                ReleaseDate = new DateTime(2017, 11, 22),
                PosterUrl = "https://upload.wikimedia.org/wikipedia/en/9/98/Coco_%282017_film%29_poster.jpg"
            };
        }

        internal static Movie SpidermanNwh()
        {
            return new Movie
            {
                Id = Guid.Parse("4fb60000-a64a-9828-e5a1-08daaa0857ff"),
                Title = "Spider-Man: No Way Home",
                InCinema = false,
                ReleaseDate = new DateTime(2022, 12, 17),
                PosterUrl = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg"
            };
        }

        internal static Movie SpidermanFfh()
        {
            return new Movie
            {
                Id = Guid.Parse("4fb60000-a64a-9828-ef3e-08daaa0857ff"),
                Title = "Spider-Man: Far From Home",
                InCinema = true,
                ReleaseDate = new DateTime(2019, 7, 2),
                PosterUrl = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg"
            };
        }

        internal static Movie Matrix()
        {
            return new Movie
            {
                Id = Guid.Parse("4fb60000-a64a-9828-f435-08daaa0857ff"),
                Title = "The Matrix",
                InCinema = true,
                ReleaseDate = new DateTime(2023, 1, 1),
                PosterUrl = "https://upload.wikimedia.org/wikipedia/en/5/50/The_Matrix_Resurrections.jpg"
            };
        }
    }
}