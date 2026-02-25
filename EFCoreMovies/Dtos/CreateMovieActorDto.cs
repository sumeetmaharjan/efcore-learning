using System;

namespace EFCoreMovies.Dtos
{
    public class CreateMovieActorDto
    {
        public Guid ActorId { get; set; }
        public string Character { get; set; }
    }
}
