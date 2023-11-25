using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreMovies.Dtos;
using EFCoreMovies.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/actors")]
    public class ActorsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;


        public ActorsController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Actors with pagination. Uses Projection
        /// </summary>
        /// <param name="page">Page</param>
        /// <param name="records">Records</param>
        /// <returns>List of Actor</returns>
        [HttpGet]
        public async Task<IEnumerable<ActorDto>> GetAll(int page = 1, int records = 2)
        {
            // AsNoTracking prevents Tracking of all the Data that is read. // Can be globally disabled from Programs.cs
            return await _dbContext.Actors.AsNoTracking()
                .OrderBy(x => x.Name)
                .ProjectTo<ActorDto>(_mapper.ConfigurationProvider)
                // Without Project Auto Mapper
                //.Select(a => new ActorDto
                //{
                //    Id = a.Id,
                //    Name = a.Name,
                //    DateOfBirth = a.DateOfBirth
                //})
                .Paginate(page, records)
                .ToListAsync();
        }

        [HttpGet("onlyIds")]
        public async Task<IEnumerable<Guid>> GetAllIds()
        {
            // AsNoTracking prevents Tracking of all the Data that is read. // Can be globally disabled from Programs.cs
            return await _dbContext.Actors.AsNoTracking()
                .Select(a => a.Id)
                .ToListAsync();
        }
    }
}
