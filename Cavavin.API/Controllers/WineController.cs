using Cavavin.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Cavavin.API.Interfaces;
using Cavavin.API.Models;
using FluentValidation;

namespace Cavavin.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WineController : ControllerBase
{
    private readonly IWineRepository _repository;
    private readonly IValidator<WineCreateDto> _validator;

    public WineController(IWineRepository repository, IValidator<WineCreateDto> validator)
    {
        _repository = repository;
        _validator  = validator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var wines = await _repository.GetAllAsync();
    
       //usage DTO
        var winesDto = wines.Select(w => new WineDto(
            w.Id,
            w.Name,
            w.Domain,
            w.Vintage,
            w.Region,
            w.Quantity
        ));
        
        return Ok(winesDto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(WineCreateDto wineDto)
    {
        var validationResult = await _validator.ValidateAsync(wineDto);
    
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        
        var wineEntity = new WineBottle {
            Name = wineDto.Name,
            Domain = wineDto.Domain,
            Vintage = wineDto.Vintage ?? 0,
            Region = wineDto.Region ?? WineRegion.Autre,
            Quantity = wineDto.Quantity ?? 1
        };

        await _repository.CreateAsync(wineEntity);

        // Renvoi DTO
        var resultDto = new WineDto(
            wineEntity.Id,
            wineEntity.Name,
            wineEntity.Domain, 
            wineEntity.Vintage,
            wineEntity.Region,
            wineEntity.Quantity
        );

        return CreatedAtAction(nameof(GetAll), new { id = wineEntity.Id }, resultDto);
    }
}