using System.ComponentModel.DataAnnotations;

namespace Cavavin.API.DTOs;

public record WineDto(
    int Id,
    string Name,
    string Domain,
    string Vintage,
    string Region,
    int Quantity
    );

public record CreateWineDto(
    [Required] string Name,
    [Required] string Domain,
    string Vintage,
    string Region,
    int Quantity
    );