using System.ComponentModel.DataAnnotations;

namespace EFCoreMovies.Dtos;

public class CreateCinemaOfferDto
{
    [Range(1, 100)]
    public double DecimalPercentage { get; set; }
    public DateTime Begin { get; set; }
    public DateTime End { get; set; }
}