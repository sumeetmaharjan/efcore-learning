using EFCoreMovies.Entities;

namespace EFCoreMovies.Dtos;

public class CreateCinemaHallDto
{
    public double Cost { get; set; }
    public CinemaHallType CinemaHallType { get; set; }
}