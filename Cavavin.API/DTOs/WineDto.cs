using System.ComponentModel.DataAnnotations;
using Cavavin.API.Models;

namespace Cavavin.API.DTOs;

public record WineDto(
    int Id,
    string Name,
    string Domain,
    int? Vintage,
    WineRegion? Region,
    int? Quantity
    );

public record WineCreateDto(
    [Required] string Name,
    [Required] string Domain,
    int? Vintage,
    WineRegion? Region,
    int? Quantity
    );