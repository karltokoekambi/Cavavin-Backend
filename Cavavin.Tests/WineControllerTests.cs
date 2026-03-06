using Cavavin.API.Controllers;
using Cavavin.API.Interfaces;
using Cavavin.API.Models;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace Cavavin.Tests;

public class WineControllerTests
{
    [Fact]
    public async Task GetAll_ReturnsOkResult_WithListOfWines()
    {
        var mockRepo = new Mock<IWineRepository>();
        mockRepo.Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(new List<WineBottle> { new WineBottle { Id = 1, Name = "Château Test" } });

        var controller = new WineController(mockRepo.Object);
        
        var result = await controller.GetAll();
        
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnWines = Assert.IsType<List<WineBottle>>(okResult.Value);
        Assert.Single(returnWines);
    }
}
