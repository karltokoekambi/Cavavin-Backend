using Cavavin.API.Controllers;
using Cavavin.API.DTOs;
using Cavavin.API.Interfaces;
using Cavavin.API.Models;
using FluentValidation;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace Cavavin.Tests;

public class WineControllerTests
{
    [Fact]
    public async Task GetAll_ReturnsOk_WithDtoList()
    {
        var mockRepo = new Mock<IWineRepository>();
        var mockValidator = new Mock<IValidator<WineCreateDto>>();
        
        var fakeWines = new List<WineBottle>
        {
            new WineBottle
            {
                Id = 1,
                Name = "Château Margaux",
                Domain = "Bordeaux",
                Vintage = 2015,
                Region = WineRegion.Bordeaux,
                Quantity = 12
            },
            new WineBottle
            {
                Id = 2,
                Name = "Pétrus",
                Domain = "Pomerol",
                Vintage = 2018,
                Region = WineRegion.Bordeaux,
                Quantity = 6
            }
        };
        mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(fakeWines);

        var controller = new WineController(mockRepo.Object, mockValidator.Object);
        
        var result = await controller.GetAll();
        
        var okResult = Assert.IsType<OkObjectResult>(result);
        var dTOs = Assert.IsAssignableFrom<IEnumerable<WineDto>>(okResult.Value);
        Assert.Equal(2, dTOs.Count());
        Assert.Equal("Château Margaux", dTOs.First().Name);
        Assert.Equal("Pétrus", dTOs.Last().Name);
        Assert.Equal(1, dTOs.First().Id);
    }
    
    [Fact]
    public async Task Create_ReturnsCreatedResult_WithNewWine()
    {
        var mockRepo = new Mock<IWineRepository>();
        var mockValidator = new Mock<IValidator<WineCreateDto>>();
        mockValidator.Setup(v => v.ValidateAsync(It.IsAny<WineCreateDto>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new FluentValidation.Results.ValidationResult());

        var controller = new WineController(mockRepo.Object, mockValidator.Object);
        var newWineDto = new WineCreateDto( "Château Test", "Domaine Test", 2020, WineRegion.Alsace, 6);
        
        var result = await controller.Create(newWineDto);
        
        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnDto = Assert.IsType<WineDto>(createdResult.Value);
        Assert.Equal("Château Test", returnDto.Name);
        Assert.Equal("Domaine Test", returnDto.Domain);
        Assert.Equal(2020, returnDto.Vintage);
        Assert.Equal(WineRegion.Alsace, returnDto.Region);
        Assert.Equal(6, returnDto.Quantity);
        
        mockRepo.Verify(r => r.CreateAsync(It.IsAny<WineBottle>()), Times.Once());
    }
}
