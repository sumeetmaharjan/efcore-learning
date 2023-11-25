using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    [Precision(18, 2)] 
    public decimal Price { get; set; }
}
