using System.Linq;
using AutoMapper;
using EFCoreMovies.Dtos;
using EFCoreMovies.Entities;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace EFCoreMovies.MappingProfile
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<Actor, ActorDto>();

            CreateMap<Cinema, CinemaDto>()
                // ~ Longitude should be value from Location.X
                .ForMember(dto => dto.Longitude, entity => entity.MapFrom(p => p.Location.X))
                .ForMember(dto => dto.Latitude, entity => entity.MapFrom(p => p.Location.Y));

            CreateMap<Genre, GenreDto>();
            CreateMap<CreateGenreDto, Genre>();

            CreateMap<Movie, MovieDto>()
                .ForMember(dto => dto.Genres, entity => entity.MapFrom(p => p.Genres.OrderByDescending(g => g.Name)))
                .ForMember(
                    dto => dto.Cinemas,
                    entity => entity.MapFrom(
                        p => p.CinemaHalls
                            .OrderByDescending(ch => ch.Cinema.Name)
                            .Select(c => c.Cinema)))
                .ForMember(dto => dto.Actors, entity => entity.MapFrom(p => p.MovieActors.Select(m => m.Actor)));

            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);


            CreateMap<CreateCinemaDto, Cinema>()
                .ForMember(
                    entity => entity.Location,
                    dto => dto.MapFrom(prop =>
                        geometryFactory.CreatePoint(
                            new Coordinate(prop.Longitude, prop.Latitude))));

            CreateMap<CreateCinemaOfferDto, CinemaOffer>();
            CreateMap<CreateCinemaHallDto, CinemaHall>();

            CreateMap<CreateMovieDto, Movie>()
                .ForMember(
                    entity => entity.Genres,
                    dto => dto.MapFrom(prop =>
                        prop.GenreIds.Select(id => new Genre() { Id = id })))
                .ForMember(entity => entity.CinemaHalls,
                    dto => dto.MapFrom(
                        p => p.CinemaHallIds.Select(id => new CinemaHall { Id = id })));

            CreateMap<CreateMovieActorDto, MovieActor>();

            CreateMap<CreateActorDto, Actor>();
        }
    }
}
