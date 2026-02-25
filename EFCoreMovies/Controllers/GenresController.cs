using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreMovies.Entities;
using EFCoreMovies.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenresController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public GenresController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Genre>> GetAll(int page = 1, int records = 2)
        {
            // AsNoTracking prevents Tracking of all the Data that is read. // Can be globally disabled from Programs.cs
            return await _dbContext.Genres.AsNoTracking()
                .OrderBy(x => x.Name)
                .Paginate(page, records)
                .ToListAsync();
        }

        [HttpGet("first")]
        public async Task<IActionResult> GetFirst()
        {
            // AsNoTracking prevents Tracking of all the Data that is read. // Can be disabled from Programs.cs
            var genre = await _dbContext.Genres.AsNoTracking().FirstOrDefaultAsync();
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> Filter(string name)
        {
            // AsNoTracking prevents Tracking of all the Data that is read. // Can be disabled from Programs.cs
            var genre = await _dbContext.Genres.AsNoTracking().Where(x => x.Name.ToLower().Contains(name)).ToListAsync();
            if (genre.Count == 0)
            {
                return NotFound();
            }
            return Ok(genre);
        }

    }
}
