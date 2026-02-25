using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using EFCoreMovies.Entities;
using EFCoreMovies.Entities.Keyless;
using EFCoreMovies.Entities.SeedData;
using EFCoreMovies.Utilities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options, IChangeTrackerEventHandler? changeTrackerEventHandler = null) :
            base(options)
        {
            if (changeTrackerEventHandler == null) return;
            
            ChangeTracker.Tracked += changeTrackerEventHandler.TrackedHandler;
            ChangeTracker.StateChanged += changeTrackerEventHandler.StateChangedHandler;
            SavingChanges += changeTrackerEventHandler.SavingChangesHandler;
            SavedChanges += changeTrackerEventHandler.SavedChangesHandler;
            SaveChangesFailed += changeTrackerEventHandler.SaveChangedFailedHandler;
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<CinemaOffer> CinemaOffers { get; set; }
        public DbSet<CinemaHall> CinemaHalls { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<CinemaDetail> CinemaDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     // This part only runs if configuration does not exist else where. 
        //     // See Program.cs 
        //     if (!optionsBuilder.IsConfigured)
        //     {
        //         optionsBuilder.UseSqlServer("name=DefaultConnection", options =>
        //         {
        //             options.UseNetTopologySuite();
        //         });
        //     }
        // }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            // Overriding the default convention
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ProcessSaveChanges();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ProcessSaveChanges()
        {
            foreach (var item in ChangeTracker.Entries()
                         .Where(e => e is { State: EntityState.Added, Entity: AuditableEntity }))
            {
                var entity = item.Entity as AuditableEntity;
                if (entity == null) continue;
                entity.CreatedBy = "Sillicon";
                entity.ModifiedBy = "Sillicon";
            }

            foreach (var item in ChangeTracker.Entries()
                         .Where(e => e is { State: EntityState.Modified, Entity: AuditableEntity }))
            {
                var entity = item.Entity as AuditableEntity;
                entity?.ModifiedBy = "Sillicon";
                item.Property(nameof(entity.CreatedBy)).IsModified = false;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Apply migration from configuration file dynamically
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Ignore Entire Entity from the Database
            // modelBuilder.Ignore<Address>();

            // This is example of Keyless entity. 
            modelBuilder.Entity<CinemaWithoutLocation>().ToSqlQuery($"SELECT Id, Name FROM Cinemas").ToView(null);
            // This is a View. Keyless entity is used for SQL view as well
            modelBuilder.Entity<MovieWithCounts>().ToView("MoviesWithCounts");

            // Initial seeding of the default data SeedStaticRelationData.cs
            SeedStaticRelationData.SeedGenreMovie(modelBuilder);
            SeedStaticRelationData.SeedCinemaHallMovie(modelBuilder);
            SeedStaticPersonMessage.SeedPersonMessage(modelBuilder);

            // Model configuration
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(string) &&
                        property.Name.Contains("URL", StringComparison.CurrentCultureIgnoreCase))
                    {
                        property.SetIsUnicode(false);
                    }
                }
            }

            //Moved to Respective Configuration Class

            ////modelBuilder.Entity<Genre>().ToTable(name: "TableGenre", schema: "movies");
            //modelBuilder.Entity<Genre>().Property(x => x.Name).HasMaxLength(20).IsRequired(); //.HasColumnName("GenreName");

            //modelBuilder.Entity<Actor>().Property(x => x.Name).HasMaxLength(50).IsRequired();
            //modelBuilder.Entity<Actor>().Property(x => x.DateOfBirth).HasColumnType("date"); // Override by above configuration. Required if Configuration Conventions is not added

            //modelBuilder.Entity<Cinema>().Property(x => x.Name).HasMaxLength(50).IsRequired();
            //modelBuilder.Entity<Cinema>().Property(x => x.Price).HasPrecision(precision: 9, scale: 2);

            //modelBuilder.Entity<CinemaHall>().Property(x => x.Cost).HasPrecision(precision: 9, scale: 2);
            //modelBuilder.Entity<CinemaHall>().Property(x => x.CinemaHallType).HasDefaultValue(CinemaHallType.TwoDimension);

            //modelBuilder.Entity<Movie>().Property(x => x.Title).HasMaxLength(150).IsRequired();
            //modelBuilder.Entity<Movie>().Property(x => x.ReleaseDate).HasColumnType("date"); // Override by above configuration. Required if Configuration Conventions is not added
            //modelBuilder.Entity<Movie>().Property(x => x.PosterUrl).HasMaxLength(500).IsUnicode(false);

            //modelBuilder.Entity<CinemaOffer>().Property(x => x.DecimalPercentage).HasPrecision(9, 2);
            //modelBuilder.Entity<CinemaOffer>().Property(x => x.Begin).HasColumnType("date");// Override by above configuration. Required if Configuration Conventions is not added
            //modelBuilder.Entity<CinemaOffer>().Property(x => x.End).HasColumnType("date");// Override by above configuration. Required if Configuration Conventions is not added

            //modelBuilder.Entity<MovieActor>().HasKey(p => new { p.MovieId, p.ActorId });
            //modelBuilder.Entity<MovieActor>().Property(p => p.Order).HasMaxLength(150);

            // Inheritance [Table Per Type]. This will split Product to different table based on the Type.
            // Will create 3 tables.. Product, Merchandising and Rentable Movie.
            modelBuilder.Entity<Merchandising>().ToTable("Merchandising");
            modelBuilder.Entity<RentableMovie>().ToTable("RentableMovies");
            var movie = new RentableMovie()
            {
                Id = Guid.Parse("0c120000-de89-ae50-2016-08dbee085f9b"),
                Name = "Spider-Man",
                MovieId = Guid.Parse("4fb60000-a64a-9828-e5a1-08daaa0857ff"),
                Price = 5.99m
            };
            var merch = new Merchandising()
            {
                Id = Guid.Parse("0c120000-de89-ae50-6d3c-08dbee085f9c"),
                Available = true,
                IsClothing = true,
                Name = "Naruto T-Shirt",
                Weight = 1,
                Volume = 1,
                Price = 11.99m
            };
            modelBuilder.Entity<Merchandising>().HasData(merch);
            modelBuilder.Entity<RentableMovie>().HasData(movie);
        }
    }
}