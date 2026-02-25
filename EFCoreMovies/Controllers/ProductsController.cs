using System.Collections.Generic;
using System.Threading.Tasks;
using EFCoreMovies.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public ProductsController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> Get()
    {
        return await _dbContext.Products.ToListAsync();
    }
    
    [HttpGet("merch")]
    public async Task<ActionResult<IEnumerable<Merchandising>>> GetMerch()
    {
        return await _dbContext.Set<Merchandising>().ToListAsync();
    }
    
    [HttpGet("rentable")]
    public async Task<ActionResult<IEnumerable<RentableMovie>>> GetRentables()
    {
        return await _dbContext.Set<RentableMovie>().ToListAsync();
    }
}
