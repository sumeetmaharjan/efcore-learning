using System;

namespace EFCoreMovies.Dtos
{
    public class ActorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
