using System;
using EFCoreMovies.Entities.Conversions;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Entities.Configurations
{
    public class CinemaHallConfiguration : IEntityTypeConfiguration<CinemaHall>
    {
        public void Configure(EntityTypeBuilder<CinemaHall> builder)
        {
            builder.Property(x => x.Cost).HasPrecision(precision: 9, scale: 2);
            builder.Property(x => x.CinemaHallType).HasDefaultValue(CinemaHallType.TwoDimension)
                .HasConversion<string>().HasMaxLength(30);
            builder.Property(p => p.Currency)
                .HasConversion<CurrencyToSymbolConverter>(); // Convert Currency to Symbol and ViceVersa

            builder.HasData(
                QfxLabim2D(),
                QfxLabim3D(),
                QfxBhaktapur3D(),
                QfxBhaktapurCxc(),
                QfxCivil2D(),
                QfxCivil3D(),
                QfxCivilCxc()
            );
        }

        internal static CinemaHall QfxLabim2D()
        {
            return new CinemaHall
            {
                Id = Guid.Parse("4fb60000-a64a-9828-2621-08daaa0901d0"),
                CinemaId = CinemaConfiguration.QfxLabim(CinemaConfiguration.GetGeometryFactory()).Id,
                Cost = 150,
                CinemaHallType = CinemaHallType.TwoDimension,
            };
        }

        internal static CinemaHall QfxLabim3D()
        {
            return new CinemaHall
            {
                Id = Guid.Parse("4fb60000-a64a-9828-697e-08daaa0901d0"),
                CinemaId = CinemaConfiguration.QfxLabim(CinemaConfiguration.GetGeometryFactory()).Id,
                Cost = 250,
                CinemaHallType = CinemaHallType.ThreeDimension,
            };
        }

        internal static CinemaHall QfxBhaktapur3D()
        {
            return new CinemaHall
            {
                Id = Guid.Parse("4fb60000-a64a-9828-7570-08daaa0901d0"),
                CinemaId = CinemaConfiguration.QfxBhaktapur(CinemaConfiguration.GetGeometryFactory()).Id,
                Cost = 250,
                CinemaHallType = CinemaHallType.ThreeDimension,
            };
        }

        internal static CinemaHall QfxBhaktapurCxc()
        {
            return new CinemaHall
            {
                Id = Guid.Parse("4fb60000-a64a-9828-7b22-08daaa0901d0"),
                CinemaId = CinemaConfiguration.QfxBhaktapur(CinemaConfiguration.GetGeometryFactory()).Id,
                Cost = 500,
                CinemaHallType = CinemaHallType.Cxc,
            };
        }

        internal static CinemaHall QfxCivil2D()
        {
            return new CinemaHall
            {
                Id = Guid.Parse("4fb60000-a64a-9828-8070-08daaa0901d0"),
                CinemaId = CinemaConfiguration.QfxCivil(CinemaConfiguration.GetGeometryFactory()).Id,
                Cost = 150,
                CinemaHallType = CinemaHallType.TwoDimension,
            };
        }

        internal static CinemaHall QfxCivil3D()
        {
            return new CinemaHall
            {
                Id = Guid.Parse("4fb60000-a64a-9828-860c-08daaa0901d0"),
                CinemaId = CinemaConfiguration.QfxCivil(CinemaConfiguration.GetGeometryFactory()).Id,
                Cost = 250,
                CinemaHallType = CinemaHallType.ThreeDimension,
            };
        }

        internal static CinemaHall QfxCivilCxc()
        {
            return new CinemaHall
            {
                Id = Guid.Parse("4fb60000-a64a-9828-8b7e-08daaa0901d0"),
                CinemaId = CinemaConfiguration.QfxCivil(CinemaConfiguration.GetGeometryFactory()).Id,
                Cost = 550,
                CinemaHallType = CinemaHallType.Cxc,
            };
        }
    }
}