using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreMovies.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Controllers;

[ApiController]
[Route("api/payments")]
public class PaymentsController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public PaymentsController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Payment>>> Get()
    {
        return await _dbContext.Payments.ToListAsync();
    }

    [HttpGet("cards")]
    public async Task<ActionResult<IEnumerable<Payment>>> GetCardPayments()
    {
        return await _dbContext.Payments.OfType<CardPayment>().ToListAsync();
    }

    [HttpGet("paypal")]
    public async Task<ActionResult<IEnumerable<Payment>>> GetPaypalPayments()
    {
        return await _dbContext.Payments.OfType<PaypalPayment>().ToListAsync();
    }
}
