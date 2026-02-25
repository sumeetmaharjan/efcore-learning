
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Entities.Configurations
{
    public class CinemaOfferConfiguration : IEntityTypeConfiguration<CinemaOffer>
    {
        public void Configure(EntityTypeBuilder<CinemaOffer> builder)
        {
            builder.Property(x => x.DecimalPercentage).HasPrecision(9, 2);
            //builder.Property(x => x.Begin).HasColumnType("date"); // Override by configuration in ApplicationDbContext OnModelCreating
            //builder.Property(x => x.End).HasColumnType("date"); // Override by configuration in ApplicationDbContext OnModelCreating

            builder.HasData(
                LabimOffer(),
                BhaktapurOffer()
                );
        }

        internal static CinemaOffer LabimOffer()
        {
            return new CinemaOffer
            {
                Id = Guid.Parse("4fb60000-a64a-9828-d903-08daaa073920"),
                CinemaId = CinemaConfiguration.QfxLabim(CinemaConfiguration.GetGeometryFactory()).Id,
                Begin = new DateTime(2022, 10, 1),
                End = new DateTime(2022, 10, 25),
                DecimalPercentage = 10
            };
        }

        internal static CinemaOffer BhaktapurOffer()
        {
            return new CinemaOffer
            {
                Id = Guid.Parse("4fb60000-a64a-9828-dc4a-08daaa073920"),
                CinemaId = CinemaConfiguration.QfxBhaktapur(CinemaConfiguration.GetGeometryFactory()).Id,
                Begin = new DateTime(2022, 10, 1),
                End = new DateTime(2022, 10, 25),
                DecimalPercentage = 13
            };
        }
    }
}
