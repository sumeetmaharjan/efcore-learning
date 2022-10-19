using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreMovies.Dtos;
using EFCoreMovies.Entities;
using EFCoreMovies.Entities.Enumerations;
using EFCoreMovies.Entities.Keyless;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/cinemas")]
    public class CinemasController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CinemasController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CinemaDto>> GetAll()
        {
            // AsNoTracking prevents Tracking of all the Data that is read. // Can be globally disabled from Programs.cs
            return await _dbContext.Cinemas.AsNoTracking()
                .OrderBy(x => x.Name)
                .ProjectTo<CinemaDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        [HttpGet("nearme")]
        public async Task<IActionResult> Get(double latitude, double longitude, int maxDistance = 2)
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            var myLocation = geometryFactory.CreatePoint(new Coordinate(latitude, longitude));
            // AsNoTracking prevents Tracking of all the Data that is read. // Can be globally disabled from Programs.cs

            var cinemas = await _dbContext.Cinemas.AsNoTracking()
                .OrderBy(x => x.Location.Distance(myLocation))
                .Where(x => x.Location.IsWithinDistance(myLocation, maxDistance * 1000))
                .Select(a => new
                {
                    Name = a.Name,
                    Distance = Math.Round(a.Location.Distance(myLocation))
                })
                .ToListAsync();
            return Ok(cinemas);
        }

        [HttpPost("predefinedHall")]
        public async Task<IActionResult> Create()
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            var cinemaLocation = geometryFactory.CreatePoint(new Coordinate(27.7285252, 85.3098711));

            var cinema = new Cinema
            {
                Name = "Guna Cinema",
                Location = cinemaLocation,
                CinemaOffer = new CinemaOffer
                {
                    DecimalPercentage = 5,
                    Begin = DateTime.Today,
                    End = DateTime.Today.AddDays(7)
                },
                CinemaHalls = new List<CinemaHall>
                {
                    new()
                    {
                        Cost = 200,
                        Currency = Currency.NepaleseRupee,
                        CinemaHallType = CinemaHallType.ThreeDimension
                    },
                    new()
                    {
                        Cost = 100,
                        Currency = Currency.UsDollar,
                        CinemaHallType = CinemaHallType.TwoDimension
                    },
                }
            };

            _dbContext.Add(cinema);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("withDto")]
        public async Task<IActionResult> CreateWithDto(CreateCinemaDto createCinemaDto)
        {
            var cinema = _mapper.Map<Cinema>(createCinemaDto);

            _dbContext.Add(cinema);
            await _dbContext.SaveChangesAsync();
            return Ok(cinema);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var cinema = await _dbContext.Cinemas
                .Include(c => c.CinemaHalls)
                .Include(c => c.CinemaOffer)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cinema is null)
            {
                return NotFound();
            }

            cinema.Location = null!;

            return Ok(cinema);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, CreateCinemaDto createCinemaDto)
        {
            // This approach handle all the condition. It can even create new records for navigation property, delete and update all at same time
            var cinema = await _dbContext.Cinemas
                .Include(c => c.CinemaHalls)
                .Include(c => c.CinemaOffer)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cinema is null)
            {
                return NotFound();
            }

            cinema = _mapper.Map(createCinemaDto, cinema);
            await _dbContext.SaveChangesAsync();
            cinema.Location = null;
            return Ok(cinema);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var cinema = await _dbContext.Cinemas
                .Include(x=>x.CinemaHalls) // Include is added for the optional Relationship.. Deleting this the cinema will add Null in the CinemaHall's CinemaId Foreignkey
                .FirstOrDefaultAsync(c => c.Id == id);
            if (cinema is null)
            {
                return NotFound();
            }

            _dbContext.Remove(cinema);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("withoutLocation")]
        public async Task<IEnumerable<CinemaWithoutLocation>> GetCinemaWithoutLocation()
        {
            return await _dbContext.Set<CinemaWithoutLocation>().ToListAsync();
        }

        // [HttpDelete("{id:guid}")]
        // public async Task<IActionResult> DeleteWithout(Guid id)
        // {
        //     var cinema = await _dbContext.Cinemas.FirstOrDefaultAsync(x => x.Id == id);
        //     if (cinema is null)
        //     {
        //         return NotFound();
        //     }
        //
        //     _dbContext.Remove(cinema);
        //     await _dbContext.SaveChangesAsync();
        //     return Ok();
        // }
    }
}