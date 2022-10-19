using System.ComponentModel.DataAnnotations;

namespace EFCoreMovies.Dtos
{
    public class CreateGenreDto
    {
        [Required]
        public string Name { get; set; }
    }
}
