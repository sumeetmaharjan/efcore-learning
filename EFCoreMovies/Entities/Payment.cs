using System;
using EFCoreMovies.Entities.Enumerations;

namespace EFCoreMovies.Entities;

public abstract class Payment
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentType PaymentType { get; set; }
}