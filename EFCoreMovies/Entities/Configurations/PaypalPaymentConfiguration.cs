using EFCoreMovies.Entities.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Entities.Configurations;

public class PaypalPaymentConfiguration : IEntityTypeConfiguration<PaypalPayment>
{
    public void Configure(EntityTypeBuilder<PaypalPayment> builder)
    {
        builder.Property(c => c.Email).IsRequired();

        builder.Property(c => c.Email).HasMaxLength(50);
        builder.HasData(DataOne(), DataTwo());
    }

    private static PaypalPayment DataOne()
    {
        return new PaypalPayment
        {
            Id = Guid.Parse("4fb60000-a64a-9828-e2c2-08dabae50088"),
            PaymentDate = new DateTime(2022, 1, 1),
            Amount = 123,
            PaymentType = PaymentType.PayPal,
            Email = "test@gmail.com"
        };
    }

    private static PaypalPayment DataTwo()
    {
        return new PaypalPayment
        {
            Id = Guid.Parse("4fb60000-a64a-9828-453c-08dabae50089"),
            PaymentDate = new DateTime(2022, 5, 14),
            Amount = 213,
            PaymentType = PaymentType.PayPal,
            Email = "test@hotmail.com"
        };
    }
}