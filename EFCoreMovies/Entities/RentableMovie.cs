using System;

namespace EFCoreMovies.Entities;

public class RentableMovie: Product
{
    public Guid MovieId { get; set; }
}
