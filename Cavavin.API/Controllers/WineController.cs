using Microsoft.AspNetCore.Mvc;
using Cavavin.API.Interfaces;
using Cavavin.API.Models;

namespace Cavavin.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WineController : ControllerBase
{
    private readonly IWineRepository _repository;

    public WineController(IWineRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var wines = await _repository.GetAllAsync();
        return Ok(wines);
    }

    [HttpPost]
    public async Task<IActionResult> Create(WineBottle wine)
    {
        await _repository.CreateAsync(wine);
        return CreatedAtAction(nameof(GetAll), new { id = wine.Id }, wine);
    }
}