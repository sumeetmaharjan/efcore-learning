using System;
using System.Globalization;

namespace EFCoreMovies.Dtos
{
    public class CinemaDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
