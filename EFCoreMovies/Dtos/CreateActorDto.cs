using System;

namespace EFCoreMovies.Dtos
{
    public class CreateActorDto
    {
        public string Name { get; set; }
        public string Biography { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
