using System;
using System.Collections.Generic;

namespace EFCoreMovies.Dtos
{
    public class MovieDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ICollection<GenreDto> Genres { get; set; }
        public ICollection<CinemaDto> Cinemas { get; set; }
        public ICollection<ActorDto> Actors { get; set; }
    }
}
