using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cavavin.API.Data;
using Cavavin.API.Models;

namespace Cavavin.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WineController : ControllerBase
{
    private readonly AppDbContext _context;

    public WineController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WineBottle>>> GetBottles()
    {
        return await _context.WineBottles.ToListAsync();
    }
}