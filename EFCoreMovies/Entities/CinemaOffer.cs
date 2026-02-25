using System;

namespace EFCoreMovies.Entities
{
    public class CinemaOffer
    {
        public Guid Id { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public decimal DecimalPercentage { get; set; }
        public Guid CinemaId { get; set; }
    }
}
