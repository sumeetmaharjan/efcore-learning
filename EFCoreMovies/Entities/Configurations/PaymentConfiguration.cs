using EFCoreMovies.Entities.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Entities.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.Property(p => p.Amount).HasPrecision(18, 2);

        builder.HasDiscriminator(p => p.PaymentType)
            .HasValue<PaypalPayment>(PaymentType.PayPal)
            .HasValue<CardPayment>(PaymentType.Card);
    }
}