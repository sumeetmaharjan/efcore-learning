using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Entities;

// [NotMapped] // Ignored from DbContext Ignore<Address>()
[Owned]
public class Address
{
    // public Guid Id { get; set; } // Id is not required for Owned Entity
    public string State { get; set; }
    [Required] // Any one property is Required for Owned Types
    public string Country { get; set; }
}