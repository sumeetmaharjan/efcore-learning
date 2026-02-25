using System.Collections.Generic;
using EFCoreMovies.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Entities.SeedData
{
    public static class SeedStaticRelationData
    {
        private const string GenresId = "GenresId";
        private const string MoviesId = "MoviesId";
        private const string CinemaHallsId = "CinemaHallsId";

        /// <summary>
        /// Seed Movies that is currently in Cinemas
        /// </summary>
        /// <param name="builder">ModelBuilder instance</param>
        public static void SeedCinemaHallMovie(ModelBuilder builder)
        {
            builder.Entity("CinemaHallMovie").HasData(
                new Dictionary<string, object>()
                {
                    [MoviesId] = MovieConfiguration.SpidermanFfh().Id,
                    [CinemaHallsId] = CinemaHallConfiguration.QfxCivil2D().Id,
                },
                new Dictionary<string, object>()
                {
                    [MoviesId] = MovieConfiguration.SpidermanFfh().Id,
                    [CinemaHallsId] = CinemaHallConfiguration.QfxCivil3D().Id,
                },
                new Dictionary<string, object>()
                {
                    [MoviesId] = MovieConfiguration.SpidermanFfh().Id,
                    [CinemaHallsId] = CinemaHallConfiguration.QfxLabim2D().Id,
                },
                new Dictionary<string, object>()
                {
                    [MoviesId] = MovieConfiguration.SpidermanFfh().Id,
                    [CinemaHallsId] = CinemaHallConfiguration.QfxLabim3D().Id,
                },
                new Dictionary<string, object>()
                {
                    [MoviesId] = MovieConfiguration.SpidermanFfh().Id,
                    [CinemaHallsId] = CinemaHallConfiguration.QfxBhaktapur3D().Id,
                },
                new Dictionary<string, object>()
                {
                    [MoviesId] = MovieConfiguration.Matrix().Id,
                    [CinemaHallsId] = CinemaHallConfiguration.QfxBhaktapur3D().Id,
                },
                new Dictionary<string, object>()
                {
                    [MoviesId] = MovieConfiguration.Matrix().Id,
                    [CinemaHallsId] = CinemaHallConfiguration.QfxCivil3D().Id,
                },
                new Dictionary<string, object>()
                {
                    [MoviesId] = MovieConfiguration.Matrix().Id,
                    [CinemaHallsId] = CinemaHallConfiguration.QfxLabim3D().Id,
                },
                new Dictionary<string, object>()
                {
                    [MoviesId] = MovieConfiguration.Matrix().Id,
                    [CinemaHallsId] = CinemaHallConfiguration.QfxBhaktapurCxc().Id,
                }
                );
        }

        /// <summary>
        /// Seed Genre of the Movie
        /// </summary>
        /// <param name="builder">ModelBuilder instance</param>
        public static void SeedGenreMovie(ModelBuilder builder)
        {
            builder.Entity("GenreMovie").HasData(
                new Dictionary<string, object>
                {
                    [GenresId] = GenreConfiguration.ScienceFriction().Id,
                    [MoviesId] = MovieConfiguration.SpidermanFfh().Id
                },
                new Dictionary<string, object>
                {
                    [GenresId] = GenreConfiguration.Action().Id,
                    [MoviesId] = MovieConfiguration.SpidermanFfh().Id
                },
                new Dictionary<string, object>
                {
                    [GenresId] = GenreConfiguration.Comedy().Id,
                    [MoviesId] = MovieConfiguration.SpidermanFfh().Id
                },
                new Dictionary<string, object>
                {
                    [GenresId] = GenreConfiguration.ScienceFriction().Id,
                    [MoviesId] = MovieConfiguration.SpidermanNwh().Id
                },
                new Dictionary<string, object>
                {
                    [GenresId] = GenreConfiguration.Action().Id,
                    [MoviesId] = MovieConfiguration.SpidermanNwh().Id
                },
                new Dictionary<string, object>
                {
                    [GenresId] = GenreConfiguration.Comedy().Id,
                    [MoviesId] = MovieConfiguration.SpidermanNwh().Id
                },
                new Dictionary<string, object>
                {
                    [GenresId] = GenreConfiguration.Animation().Id,
                    [MoviesId] = MovieConfiguration.Coco().Id
                },
                new Dictionary<string, object>
                {
                    [GenresId] = GenreConfiguration.Action().Id,
                    [MoviesId] = MovieConfiguration.Avengers().Id
                },
                new Dictionary<string, object>
                {
                    [GenresId] = GenreConfiguration.ScienceFriction().Id,
                    [MoviesId] = MovieConfiguration.Avengers().Id
                }
            );
        }


        //private static object[] DataForCinemaHall()
        //{
        //    return new object[]
        //    {
        //        new Dictionary<string, object>()
        //        {
        //            [MoviesId] = MovieConfiguration.SpidermanFFH().Id,
        //            [CinemaHallsId] = CinemaHallConfiguration.QfxCivil2D().Id,
        //        },
        //        new Dictionary<string, object>()
        //        {
        //            [MoviesId] = MovieConfiguration.SpidermanFFH().Id,
        //            [CinemaHallsId] = CinemaHallConfiguration.QfxCivil3D().Id,
        //        },
        //        new Dictionary<string, object>()
        //        {
        //            [MoviesId] = MovieConfiguration.SpidermanFFH().Id,
        //            [CinemaHallsId] = CinemaHallConfiguration.QfxLabim2D().Id,
        //        },
        //        new Dictionary<string, object>()
        //        {
        //            [MoviesId] = MovieConfiguration.SpidermanFFH().Id,
        //            [CinemaHallsId] = CinemaHallConfiguration.QfxLabim3D().Id,
        //        },
        //        new Dictionary<string, object>()
        //        {
        //            [MoviesId] = MovieConfiguration.SpidermanFFH().Id,
        //            [CinemaHallsId] = CinemaHallConfiguration.QfxBhaktapur3D().Id,
        //        },
        //        new Dictionary<string, object>()
        //        {
        //            [MoviesId] = MovieConfiguration.Matrix().Id,
        //            [CinemaHallsId] = CinemaHallConfiguration.QfxBhaktapur3D().Id,
        //        },
        //        new Dictionary<string, object>()
        //        {
        //            [MoviesId] = MovieConfiguration.Matrix().Id,
        //            [CinemaHallsId] = CinemaHallConfiguration.QfxCivil3D().Id,
        //        },
        //        new Dictionary<string, object>()
        //        {
        //            [MoviesId] = MovieConfiguration.Matrix().Id,
        //            [CinemaHallsId] = CinemaHallConfiguration.QfxLabim3D().Id,
        //        },
        //        new Dictionary<string, object>()
        //        {
        //            [MoviesId] = MovieConfiguration.Matrix().Id,
        //            [CinemaHallsId] = CinemaHallConfiguration.QfxBhaktapurCxc().Id,
        //        }
        //    };
        //}

        //private static object[] FfhGenre()
        //{
        //    return new object[]
        //    {
        //        new Dictionary<string, object>
        //        {
        //            [GenresId] = GenreConfiguration.ScienceFriction().Id,
        //            [MoviesId] = MovieConfiguration.SpidermanFFH().Id
        //        },
        //        new Dictionary<string, object>
        //        {
        //            [GenresId] = GenreConfiguration.Action().Id,
        //            [MoviesId] = MovieConfiguration.SpidermanFFH().Id
        //        },
        //        new Dictionary<string, object>
        //        {
        //            [GenresId] = GenreConfiguration.Comedy().Id,
        //            [MoviesId] = MovieConfiguration.SpidermanFFH().Id
        //        }
        //    };
        //}

        //private static object[] NwhGenre()
        //{
        //    return new object[]
        //    {
        //        new Dictionary<string, object>
        //        {
        //            [GenresId] = GenreConfiguration.ScienceFriction().Id,
        //            [MoviesId] = MovieConfiguration.SpidermanNWH().Id
        //        },
        //        new Dictionary<string, object>
        //        {
        //            [GenresId] = GenreConfiguration.Action().Id,
        //            [MoviesId] = MovieConfiguration.SpidermanNWH().Id
        //        },
        //        new Dictionary<string, object>
        //        {
        //            [GenresId] = GenreConfiguration.Comedy().Id,
        //            [MoviesId] = MovieConfiguration.SpidermanNWH().Id
        //        }
        //    };
        //}

        //private static object[] CocoGenre()
        //{
        //    return new object[]
        //    {
        //        new Dictionary<string, object>
        //        {
        //            [GenresId] = GenreConfiguration.Animation().Id,
        //            [MoviesId] = MovieConfiguration.Coco().Id
        //        }
        //    };
        //}

        //private static object[] AvengersGenre()
        //{
        //    return new object[]
        //    {
        //        new Dictionary<string, object>
        //        {
        //            [GenresId] = GenreConfiguration.Action().Id,
        //            [MoviesId] = MovieConfiguration.Avengers().Id
        //        },
        //        new Dictionary<string, object>
        //        {
        //            [GenresId] = GenreConfiguration.ScienceFriction().Id,
        //            [MoviesId] = MovieConfiguration.Avengers().Id
        //        }
        //    };
        //}
    }
}