namespace EFCoreMovies.Entities;

public class RentMovie
{
    public Guid Id { get; set; }
    public Guid MovieId { get; set; }
    public DateTime EndOfRent { get; set; }
    public Guid PaymentId { get; set; }
    public Payment Payment { get; set; }
    public Movie Movie { get; set; }
    
}
