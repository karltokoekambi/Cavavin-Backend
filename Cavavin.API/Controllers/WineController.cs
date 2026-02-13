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
    
    [HttpPost]
    public async Task<ActionResult<WineBottle>> PostWine(WineBottle bottle)
    {
        bottle.Id = 0; 

        _context.WineBottles.Add(bottle);
        await _context.SaveChangesAsync();

        return Ok(bottle); 
    }
}