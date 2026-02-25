
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Entities.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            //modelBuilder.Entity<Genre>().ToTable(name: "TableGenre", schema: "movies");
            builder.Property(x => x.Name).HasMaxLength(20).IsRequired(); //.HasColumnName("GenreName");
            builder.HasQueryFilter(q => !q.IsDeleted); // Applied to all the query on genre
            // builder.HasIndex(p => p.Name).IsUnique(); // This is how you add Index
            builder.HasIndex(p => p.Name).IsUnique()
                .HasFilter(
                    "IsDeleted = 'false'"); // This is for Ignoring SoftDeleted so that Name that has be soft deleted can be used again 
            builder.HasData(SeedGenreData());
            builder.Property(x => x.CreatedBy).HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasMaxLength(50).IsRequired(false);
            builder.Property<DateTime>("CreatedDate").HasDefaultValueSql("GetDate()").HasColumnType("datetime2");
        }

        private static IEnumerable<Genre> SeedGenreData()
        {
            return new List<Genre>()
            {
                Animation(),
                Action(),
                Comedy(),
                ScienceFriction(),
                Drama()
            };
        }

        internal static Genre Action()
        {
            return new Genre { Id = Guid.Parse("4fb60000-a64a-9828-0da5-08daaa06a9ca"), Name = "Action" };
        }

        internal static Genre Animation()
        {
            return new Genre { Id = Guid.Parse("4fb60000-a64a-9828-cdff-08daaa06a9cb"), Name = "Animation" };
        }

        internal static Genre Comedy()
        {
            return new Genre { Id = Guid.Parse("4fb60000-a64a-9828-dd58-08daaa06a9cb"), Name = "Comedy" };
        }

        internal static Genre ScienceFriction()
        {
            return new Genre { Id = Guid.Parse("4fb60000-a64a-9828-e0dd-08daaa06a9cb"), Name = "Science Friction" };
        }

        internal static Genre Drama()
        {
            return new Genre { Id = Guid.Parse("4fb60000-a64a-9828-e3c4-08daaa06a9cb"), Name = "Drama" };
        }
    }
}