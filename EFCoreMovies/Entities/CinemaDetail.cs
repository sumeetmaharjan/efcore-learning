﻿using System.ComponentModel.DataAnnotations;

namespace EFCoreMovies.Entities;
// This is Example of Splitting the Table into Two Entities
public class CinemaDetail
{
    public Guid Id { get; set; }
    [Required]
    public string History { get; set; }
    public string Values { get; set; }
    public string Missions { get; set; }
    public string CodeOfConduct { get; set; }
    public Cinema Cinema { get; set; }
}