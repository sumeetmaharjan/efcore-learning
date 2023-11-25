using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Entities.Configurations
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Biography).HasMaxLength(500);
            builder.Ignore(x => x.Age); // Equivalent to [NotMapped] annotation on Actor Entity
            builder.HasData(SeedActorData());
        }

        private static IEnumerable<Actor> SeedActorData()
        {
            return new List<Actor>
            {
                TomHolland(),
                AuliCravalho(),
                ChrisEvans(),
                KeanuReeves(),
                LaRoca(),
                RobertDowneyJr(),
                SamuelJackson(),
                ScarlettJohansson()
            };
        }

        internal static Actor TomHolland()
        {
            return new Actor
            {
                Id = Guid.Parse("4fb60000-a64a-9828-ea48-08daaa06a9cb"), Name = "Tom Holland",
                DateOfBirth = new DateTime(1996, 6, 1),
                Biography =
                    "Thomas Stanley Holland (born 1 June 1996) is an English actor. He is recipient of several accolades, including the 2017 BAFTA Rising Star Award. Holland began his acting career as a child actor on the West End stage in Billy Elliot the Musical at the Victoria Palace Theater in 2008, playing a supporting part"
            };
        }

        internal static Actor SamuelJackson()
        {
            return new Actor
            {
                Id = Guid.Parse("4fb60000-a64a-9828-f090-08daaa06a9cb"), Name = "Samuel L. Jackson",
                DateOfBirth = new DateTime(1948, 12, 21),
                Biography =
                    "Samuel Leroy Jackson (born December 21, 1948) is an American actor and producer. One of the most widely recognized actors of his generation, the films in which he has appeared have collectively grossed over $27 billion worldwide, making him the highest-grossing actor of all time (excluding cameo appearances and voice roles)."
            };
        }

        internal static Actor RobertDowneyJr()
        {
            return new Actor
            {
                Id = Guid.Parse("4fb60000-a64a-9828-f42a-08daaa06a9cb"), Name = "Robert Downey Jr.",
                DateOfBirth = new DateTime(1965, 4, 4),
                Biography =
                    "Robert John Downey Jr. (born April 4, 1965) is an American actor and producer. His career has been characterized by critical and popular success in his youth, followed by a period of substance abuse and legal troubles, before a resurgence of commercial success later in his career."
            };
        }

        internal static Actor ChrisEvans()
        {
            return new Actor
            {
                Id = Guid.Parse("4fb60000-a64a-9828-f6bf-08daaa06a9cb"), Name = "Chris Evans",
                DateOfBirth = new DateTime(1981, 06, 13)
            };
        }

        internal static Actor LaRoca()
        {
            return new Actor
            {
                Id = Guid.Parse("4fb60000-a64a-9828-f97f-08daaa06a9cb"), Name = "Dwayne Johnson",
                DateOfBirth = new DateTime(1972, 5, 2)
            };
        }

        internal static Actor AuliCravalho()
        {
            return new Actor
            {
                Id = Guid.Parse("4fb60000-a64a-9828-fc0c-08daaa06a9cb"), Name = "Auli'i Cravalho",
                DateOfBirth = new DateTime(2000, 11, 22)
            };
        }

        internal static Actor ScarlettJohansson()
        {
            return new Actor
            {
                Id = Guid.Parse("4fb60000-a64a-9828-ff1f-08daaa06a9cb"), Name = "Scarlett Johansson",
                DateOfBirth = new DateTime(1984, 11, 22)
            };
        }

        internal static Actor KeanuReeves()
        {
            return new Actor
            {
                Id = Guid.Parse("4fb60000-a64a-9828-0235-08daaa06a9cc"), Name = "Keanu Reeves",
                DateOfBirth = new DateTime(1964, 9, 2)
            };
        }
    }
}
