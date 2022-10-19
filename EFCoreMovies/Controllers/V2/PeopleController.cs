using EFCoreMovies.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Controllers.V2;

[ApiController]
[Route("api/people")]
public class PeopleController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public PeopleController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Person>> Get(Guid id)
    {
        var person = await _dbContext.Persons
            .Include(x => x.ReceivedMessages)
            .Include(x => x.SentMessages)
            .FirstOrDefaultAsync(x => x.Id == id);
        if (person is null)
        {
            return NotFound();
        }

        return person;
    }
}