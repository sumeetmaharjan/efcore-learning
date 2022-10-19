using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreMovies.Dtos;
using EFCoreMovies.Entities;
using EFCoreMovies.Entities.Keyless;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Controllers.V2
{
    [ApiController]
    [Route("v2/api/movies")]
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
        public async Task<IActionResult> GetWithAutoMapper(Guid id)
        {
            var movie = await _dbContext.Movies
                .AsNoTracking()
                .ProjectTo<MovieDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (movie == null) return NotFound();

            var movieDto = _mapper.Map<MovieDto>(movie);

            movieDto.Cinemas = movieDto.Cinemas.DistinctBy(x => x.Id).ToList();
            return Ok(movieDto);
        }


        [HttpPost]
        public async Task<IActionResult> CreateWithDto(CreateMovieDto createMovieDto)
        {
            var movie = _mapper.Map<Movie>(createMovieDto);

            movie.Genres.ForEach(g => _dbContext.Entry(g).State = EntityState.Unchanged);
            movie.CinemaHalls.ForEach(ch => _dbContext.Entry(ch).State = EntityState.Unchanged);

            if (movie.MovieActors.Count > 0)
            {
                var i = 1;
                foreach (var actor in movie.MovieActors)
                {
                    actor.Order = i + 1;
                    i++;
                }
            }

            _dbContext.Add(movie);
            await _dbContext.SaveChangesAsync();
            return Ok(movie);
        }

        [HttpGet("withCount")]
        public async Task<IEnumerable<MovieWithCounts>> GetMovieWithCount()
        {
            return await _dbContext.Set<MovieWithCounts>().ToListAsync();
        }
    }
}