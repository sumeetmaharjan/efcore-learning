          using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace EFCoreMovies.Entities.Configurations
{
    public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();

            // One to One Relationship using FluentAPI. Cinema has one Cinema offer. 
            builder
                .HasOne(c => c.CinemaOffer) // Read as Cinema.HasOne.CinemaOffer.Meanwhile.CinemaOffer.Has.One.Cinema
                .WithOne()
                .HasForeignKey<
                    CinemaOffer>(co =>
                    co.CinemaId); // HasForeignKey Optional as we follow convention. If CinemaId was MeroCinemaId then it is required

            // One to Many Relationship using FluentAPI. Cinema has Many CinemaHall
            builder.HasMany(c => c.CinemaHalls) //Read as Cinema.HasMany.CinemaHall.Meanwhile.CinemaHall.Has.One.Cinema
                .WithOne(ch => ch.Cinema) // Needs ch=>ch.Cinema because CinemaHall has Cinema
                .HasForeignKey(ch => ch.CinemaId)
                .OnDelete(DeleteBehavior.Restrict);

            // This is split entity. It is not a new table but split from Cinema table
            builder.HasOne(c => c.CinemaDetail).WithOne(c => c.Cinema).HasForeignKey<CinemaDetail>(cd => cd.Id);

            // Change the column name of the address in Cinema Table 
            builder.OwnsOne(c => c.Address, add =>
            {
                add.Property(p => p.State).HasColumnName("State");
                add.Property(p => p.Country).HasColumnName("Country");
            });
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            builder.HasData(
                QfxLabim(geometryFactory),
                QfxBhaktapur(geometryFactory),
                QfxCivil(geometryFactory)
            );
        }

        internal static GeometryFactory GetGeometryFactory()
        {
            return NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
        }

        internal static Cinema QfxLabim(GeometryFactory geometryFactory)
        {
            return new Cinema
            {
                Id = Guid.Parse("4fb60000-a64a-9828-04f7-08daaa06a9cc"), Name = "Labim Mall",
                Location = geometryFactory.CreatePoint(new Coordinate(27.6772126, 85.317018))
            };
        }

        internal static Cinema QfxCivil(GeometryFactory geometryFactory)
        {
            return new Cinema
            {
                Id = Guid.Parse("4fb60000-a64a-9828-07a5-08daaa06a9cc"), Name = "Civil Mall",
                Location = geometryFactory.CreatePoint(new Coordinate(27.6992707, 85.3084962))
            };
        }

        internal static Cinema QfxBhaktapur(GeometryFactory geometryFactory)
        {
            return new Cinema
            {
                Id = Guid.Parse("4fb60000-a64a-9828-09ed-08daaa06a9cc"), Name = "Bhaktapur Mall",
                Location = geometryFactory.CreatePoint(new Coordinate(27.6751519, 85.3968551))
            };
        }
    }
}
