namespace EFCoreMovies.Entities;

// [NotMapped] // Ignored from DbContext Ignore<Address>()
public class Address
{
    public Guid Id { get; set; }
    public string Country { get; set; }
}