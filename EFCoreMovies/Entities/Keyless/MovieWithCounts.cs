namespace EFCoreMovies.Entities.Keyless;

// MovieWithCount is a View In SQL. Created via Migration
public class MovieWithCounts
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int AmountGenre { get; set; }
    public int AmountCinemas { get; set; }
    public int AmountActor { get; set; }
}