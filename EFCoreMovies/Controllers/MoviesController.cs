using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreMovies.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public MoviesController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAll(Guid id)
        {
            // AsNoTracking prevents Tracking of all the Data that is read. // Can be globally disabled from Programs.cs
            var movie = await _dbContext.Movies
                .AsNoTracking()
                .Include(x => x.Genres.OrderByDescending(g => g.Name).Where(g => !g.Name.Contains("m")))
                .Include(x => x.CinemaHalls.OrderByDescending(ch => ch.Cinema.Name))
                    .ThenInclude(x => x.Cinema)
                .Include(x => x.MovieActors)
                    .ThenInclude(x => x.Actor)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (movie == null) return NotFound();

            var movieDto = _mapper.Map<MovieDto>(movie);

            movieDto.Cinemas = movieDto.Cinemas.DistinctBy(x => x.Id).ToList();
            return Ok(movieDto);
        }

        [HttpGet("automapper/{id:guid}")]
        public async Task<IActionResult> GetWithAutoMapper(Guid id)
        {
            // AsNoTracking prevents Tracking of all the Data that is read. // Can be globally disabled from Programs.cs
            var movie = await _dbContext.Movies
                .AsNoTracking()
                .ProjectTo<MovieDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (movie == null) return NotFound();

            var movieDto = _mapper.Map<MovieDto>(movie);

            movieDto.Cinemas = movieDto.Cinemas.DistinctBy(x => x.Id).ToList();
            return Ok(movieDto);
        }

        [HttpGet("selectLoading/{id:guid}")]
        public async Task<IActionResult> GetWithSelectLoading(Guid id)
        {
            // Return anonymous type with Id Title and Genre with only Name
            var movieDto = await _dbContext.Movies.Select(m => new
            {
                m.Id,
                m.Title,
                Genres = m.Genres.Select(g => g.Name).OrderByDescending(n => n).ToList()
            }).FirstOrDefaultAsync(m => m.Id == id);

            if (movieDto == null) return NotFound();
            return Ok(movieDto);
        }

        [HttpGet("explicitLoading/{id:guid}")]
        public async Task<ActionResult<MovieDto>> GetWithExplicitLoading(Guid id)
        {
            var movie = await _dbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);

            if (movie == null) return NotFound();

            var genreCount = await _dbContext.Entry(movie).Collection(p => p.Genres).Query().CountAsync(); // Demo Only

            await _dbContext.Entry(movie).Collection(p => p.Genres).LoadAsync(); // Very Inefficient.. use eager loading                                                                                                    

            var movieDto = _mapper.Map<MovieDto>(movie);
            //return movieDto;
            return Ok(new
            {
                movieDto.Id,
                movieDto.Title,
                movieDto.Genres,
                GenreCount = genreCount,
            });
        }

        [HttpGet("lazyLoading/{id:guid}")]
        public async Task<IActionResult> GetWithLazyLoading(Guid id)
        {
            //var movie = await _dbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);
            //if (movie == null) return NotFound();

            //var movieDto = _mapper.Map<MovieDto>(movie);

            //movieDto.Cinemas = movieDto.Cinemas.DistinctBy(x => x.Id).ToList();

            //return movieDto;
            return Ok("Disabled For Performance");
        }

        [HttpGet("groupByCinema")]
        public async Task<IActionResult> GetGroupedByCinema()
        {
            var groupedMovies = await _dbContext.Movies.GroupBy(m => m.InCinema).Select(n => new
            {
                InCinema = n.Key,
                Count = n.Count(),
                Movies = n.ToList()
            }).ToListAsync();
            return Ok(groupedMovies);
        }

        [HttpGet("groupByGenreCount")]
        public async Task<IActionResult> GetGroupedByGenreCount()
        {
            var groupedMovies = await _dbContext.Movies.GroupBy(m => m.Genres.Count).Select(n => new
            {
                Count = n.Key,
                Title = n.Select(x => x.Title),
                // Flatten the genre which will be listed multiple time to show only single instance of that
                Genres = n.Select(m => m.Genres).SelectMany(a => a).Select(g => g.Name).Distinct()
            }).ToListAsync();
            return Ok(groupedMovies);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<MovieDto>>> Filter([FromQuery] MovieFilterDto moviesFilterDto)
        {
            var queryableMovie = _dbContext.Movies.AsQueryable();

            if (!string.IsNullOrEmpty(moviesFilterDto.Title))
            {
                queryableMovie = queryableMovie.Where(m => m.Title.Contains(moviesFilterDto.Title));
            }

            if (moviesFilterDto.InCinema.HasValue)
            {
                queryableMovie = queryableMovie.Where(m => m.InCinema);
            }

            if (moviesFilterDto.UpCommingRelease.HasValue)
            {
                var today = DateTime.Today;
                queryableMovie = queryableMovie.Where(m => m.ReleaseDate > today);
            }

            if (moviesFilterDto.GenreId.HasValue && moviesFilterDto.GenreId.Value != Guid.Empty)
            {
                queryableMovie =
                    queryableMovie.Where(m => m.Genres.Select(g => g.Id).Contains(moviesFilterDto.GenreId.Value));
            }

            var movies = await queryableMovie.Include(x => x.Genres).ToListAsync();
            return _mapper.Map<List<MovieDto>>(movies);
        }
    }
}
