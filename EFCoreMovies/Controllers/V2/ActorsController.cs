using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreMovies.Dtos;
using EFCoreMovies.Entities;
using EFCoreMovies.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Controllers.V2
{
    [ApiController]
    [Route("v2/api/actors")]
    public class ActorsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;


        public ActorsController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<ActorDto>> GetAll(int page = 1, int records = 2)
        {
            return await _dbContext.Actors.AsNoTracking()
                .OrderBy(x => x.Name)
                .ProjectTo<ActorDto>(_mapper.ConfigurationProvider)
                .Paginate(page, records)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateActorDto createActorDto)
        {
            var actor = _mapper.Map<Actor>(createActorDto);
            _dbContext.Add(actor);
            await _dbContext.SaveChangesAsync();
            return Ok(actor);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, CreateActorDto createActorDto)
        {
            // This approach generate update query that only changes the value that is updated
            var actorInDb = await _dbContext.Actors.FirstOrDefaultAsync(x => x.Id == id);
            if (actorInDb == null) return NotFound();

            actorInDb = _mapper.Map(createActorDto, actorInDb);
            await _dbContext.SaveChangesAsync();

            return Ok(actorInDb);
        }

        [HttpPut("disconnected/{id:guid}")]
        public async Task<IActionResult> UpdateDisconnected(Guid id, CreateActorDto createActorDto)
        {
            // This approach generate update query that changes all the value of the table
            var existActor = await _dbContext.Actors.FirstOrDefaultAsync(x => x.Id == id);
            if (existActor == null) return NotFound();

            var actor = _mapper.Map<Actor>(createActorDto);
            actor.Id = id;

            _dbContext.Update(actor);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }


    }
}
