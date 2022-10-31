using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Entities.Configurations;

public class CinemaDetailConfiguration : IEntityTypeConfiguration<CinemaDetail>
{
    public void Configure(EntityTypeBuilder<CinemaDetail> builder)
    {
        // Tells that CinemaDetail is in Cinemas Table
        builder.ToTable("Cinemas");
    }
}