using Cavavin.API.DTOs;
using Cavavin.API.Models;
using Cavavin.API.Validators;

namespace Cavavin.Tests.Validators;

public class WineValidatorTests
{
    [Fact]
    public void Should_Have_Error_When_Vintage_Is_In_Future()
    {
        // Arrange
        var validator = new WineCreateDtoValidator();
        var dto = new WineCreateDto( "Chateau La Vigne", "Domaine de la Vigne", 2050, WineRegion.Bordeaux, 10);

        // Act
        var result = validator.Validate(dto);

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, x => x.PropertyName == "Vintage");
    }
}