using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreMovies.Entities
{
    public class Actor
    {
        public Guid Id { get; set; }
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = string.Join(' ', value.Split(' ')
                            .Select(n => n[0].ToString().ToUpper() + n[1..].ToLower()).ToArray());
            }
        }

        public string? Biography { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public int? Age
        {
            get
            {
                if (!DateOfBirth.HasValue) return null;
                
                var dob = DateOfBirth.Value;
                var age = DateTime.Today.Year - dob.Year;
                if (new DateTime(DateTime.Today.Year, dob.Month, dob.Day) > DateTime.Today)
                {
                    age--;
                }
                return age;

            }
        }

        public string? PictureURL { get; set; }
        public Address BillingAddress { get; set; }
        public Address HomeAddress { get; set; }
        public virtual ICollection<MovieActor> MovieActors { get; set; } // None Skip Style Many-Many RelationShip Look at MovieActor
    }
}
