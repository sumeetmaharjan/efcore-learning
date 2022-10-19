using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreMovies.Dtos;
using EFCoreMovies.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Controllers.V2
{
    [ApiController]
    [Route("v2/api/genres")]
    public class GenresController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GenresController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<GenreDto>> GetAll()
        {
            return await _dbContext.Genres.AsNoTracking()
                //.Where(x=>!x.IsDeleted)  // Applied through query filter on GenreConfig
                .OrderBy(x => x.Name)
                .ProjectTo<GenreDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        [HttpGet("orderByShadowProperty")]
        public async Task<IEnumerable<GenreDto>> GetAllOrderbyShadowProperty()
        {
            return await _dbContext.Genres.AsNoTracking()
                .OrderByDescending(x => EF.Property<DateTime>(x, "CreatedDate"))
                .ProjectTo<GenreDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GenreDto>> GetById(Guid id)
        {
            var genre = await _dbContext.Genres.FirstOrDefaultAsync(x => x.Id == id);
            if (genre is null)
            {
                return NotFound();
            }

            // This is a shadow property of the Genre
            var createdDate = _dbContext.Entry(genre).Property<DateTime>("CreatedDate").CurrentValue;
            return Ok(new
            {
                Id = genre.Id,
                Name = genre.Name,
                CreatedDate = createdDate
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateGenreDto createGenreDto)
        {
            var genreExist = await _dbContext.Genres.AnyAsync(x => x.Name == createGenreDto.Name);
            if (genreExist)
            {
                return BadRequest($"The Genre with name {createGenreDto.Name} already exist");
            }

            var genre = _mapper.Map<Genre>(createGenreDto);
            //var status1 = _dbContext.Entry(genre).State;
            _dbContext.Add(genre); // Marked for insertion 
            //var status2 = _dbContext.Entry(genre).State;
            await _dbContext.SaveChangesAsync();
            //var status3 = _dbContext.Entry(genre).State;
            return Ok(genre);
        }

        [HttpPost("bulk")]
        public async Task<IActionResult> Create(CreateGenreDto[] genresDto)
        {
            var genres = _mapper.Map<Genre[]>(genresDto);
            if (!genres.Any()) return BadRequest();

            await _dbContext.AddRangeAsync(genres);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var genre = await _dbContext.Genres.FirstOrDefaultAsync(p => p.Id == id);
            if (genre is null)
            {
                return NotFound();
            }

            _dbContext.Remove(genre);
            await _dbContext.SaveChangesAsync();
            return Ok(genre);
        }

        [HttpDelete("softDelete/{id:guid}")]
        public async Task<IActionResult> DeleteSoft(Guid id)
        {
            var genre = await _dbContext.Genres.FirstOrDefaultAsync(p => p.Id == id);
            if (genre is null) return NotFound();
            genre.IsDeleted = true;
            await _dbContext.SaveChangesAsync();
            return Ok(genre);
        }

        [HttpPost("restoreSoftDelete/{id:guid}")]
        public async Task<IActionResult> RestoreDeleteSoft(Guid id)
        {
            var genre = await _dbContext.Genres
                .IgnoreQueryFilters() // Bypass all the filters in GenreConfiguration
                .FirstOrDefaultAsync(p => p.Id == id);
            if (genre is null) return NotFound();
            genre.IsDeleted = false;
            await _dbContext.SaveChangesAsync();
            return Ok(genre);
        }
    }
}