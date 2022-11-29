using EFCoreMovies.Entities.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Entities.Configurations;

public class CardPaymentConfiguration : IEntityTypeConfiguration<CardPayment>
{
    public void Configure(EntityTypeBuilder<CardPayment> builder)
    {
        builder.Property(p => p.Last4Digit).HasColumnType("char(4)").IsRequired();
        builder.HasData(DataOne(), DataTwo());
    }

    private static CardPayment DataOne()
    {
        return new CardPayment
        {
            Id = Guid.Parse("4fb60000-a64a-9828-363b-08dabae55e02"),
            PaymentDate = new DateTime(2022, 3, 8),
            Amount = 852,
            PaymentType = PaymentType.Card,
            Last4Digit = "1234"
        };
    }

    private static CardPayment DataTwo()
    {
        return new CardPayment
        {
            Id = Guid.Parse("4fb60000-a64a-9828-7a5c-08dabae55e02"),
            PaymentDate = new DateTime(2022, 8, 9),
            Amount = 456,
            PaymentType = PaymentType.Card,
            Last4Digit = "3214"
        };
    }
}