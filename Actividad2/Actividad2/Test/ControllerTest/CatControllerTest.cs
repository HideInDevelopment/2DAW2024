using Actividad2.Controller;
using Actividad2.Domain.Dto;
using Actividad2.Domain.Enum;
using Actividad2.Domain.Generic.Interface;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Actividad2.Test.ControllerTest;

[TestFixture]
public class CatControllerTest
{
    private readonly Mock<IEntityService<Guid, CatDto>> _mockedCatService;
    private readonly CatController _catController;

    public CatControllerTest()
    {
        _mockedCatService = new Mock<IEntityService<Guid, CatDto>>();
        _catController = new CatController(_mockedCatService.Object);
    }

    [Test]
    public void GetCats_ThenReturnHttpOKWithCats()
    {
        // Arrange
        var cats = new List<CatDto>
        {
            new(Guid.Empty, "Tako", 1, "Comun europeo", 5, HealthState.Healthy, Guid.Empty),
            new(Guid.Empty, "Yaki", 1, "Bombay", 5, HealthState.Sick, Guid.Empty),
            new(Guid.Empty, "Happy", 12, "Persa", 5, HealthState.Healthy, Guid.Empty),
            new(Guid.Empty, "Garfield", 5, "Maine Coon", 5, HealthState.Sick, Guid.Empty),
            new(Guid.Empty, "Meatball", 9, "Ragdoll", 5, HealthState.Critic, Guid.Empty),
        };
        
        _mockedCatService.Setup(m => m.Get()).Returns(cats);
        
        // Act
        var result = _catController.GetCats();

        // Assert
        result.Should().BeOfType<OkObjectResult>();
    }
    
    [Test]
    public void GetCats_ThenReturnHttpNotFound()
    {
        // Arrange
        _mockedCatService.Setup(m => m.Get()).Returns(new List<CatDto>());
        
        // Act
        var result = _catController.GetCats();

        // Assert
        result.Should().BeOfType<NotFoundResult>();
    }

    [Test]
    public void GetCat_WithValidId_ThenReturnHttpOkWithCat()
    {
        // Arrange
        var cat = new CatDto(new Guid("8cb35a91-054b-4d1a-902f-5cc5fdf9ee97"), "Tako", 1, 
            "Comun europeo", 5, HealthState.Healthy, new Guid("c785f08a-7d2c-4a8b-abb5-91d0e575fe8b"));
        _mockedCatService.Setup(m => m.Get(cat.Id)).Returns(cat);
        
        // Act
        var result = _catController.GetCat(cat.Id);
        
        // Arrange
        result.Should().BeOfType<OkObjectResult>();
    }
    
    [Test]
    public void GetCat_WithInvalidId_ThenReturnHttpNotFound()
    {
        // Arrange
        _mockedCatService.Setup(m => m.Get(Guid.Empty)).Returns(new CatDto());
        
        // Act
        var result = _catController.GetCat(Guid.Empty);

        // Assert
        result.Should().BeOfType<NotFoundResult>();
    }
    
    [Test]
    public void CreateCat_WithValidEntity_ThenReturnHttpOkWithCreatedCat()
    {
        // Arrange
        var cat = new CatDto(new Guid("8cb35a91-054b-4d1a-902f-5cc5fdf9ee97"), "Tako", 1, 
            "Comun europeo", 5, HealthState.Healthy, new Guid("c785f08a-7d2c-4a8b-abb5-91d0e575fe8b"));
        _mockedCatService.Setup(m => m.Create(cat)).Returns(cat);
        
        // Act
        var result = _catController.CreateCat(cat);
        
        // Arrange
        result.Should().BeOfType<OkObjectResult>();
    }
    
    [Test]
    public void CreateCat_WithInvalidEntity_ThenReturnHttpNotFound()
    {
        // Arrange
        _mockedCatService.Setup(m => m.Create(new CatDto())).Returns(new CatDto());
        
        // Act
        var result = _catController.CreateCat(new CatDto());

        // Assert
        result.Should().BeOfType<NotFoundResult>();
    }
    
    [Test]
    public void UpdateCat_WithValidEntity_ThenReturnHttpOkWithUpdatedCat()
    {
        // Arrange
        var cat = new CatDto(new Guid("8cb35a91-054b-4d1a-902f-5cc5fdf9ee97"), "Tako", 1, 
            "Comun europeo", 5, HealthState.Healthy, new Guid("c785f08a-7d2c-4a8b-abb5-91d0e575fe8b"));
        _mockedCatService.Setup(m => m.Update(cat)).Returns(cat);
        
        // Act
        var result = _catController.UpdateCat(cat);
        
        // Arrange
        result.Should().BeOfType<OkObjectResult>();
    }
    
    [Test]
    public void UpdateCat_WithInvalidEntity_ThenReturnHttpNotFound()
    {
        // Arrange
        _mockedCatService.Setup(m => m.Update(new CatDto())).Returns(new CatDto());
        
        // Act
        var result = _catController.UpdateCat(new CatDto());

        // Assert
        result.Should().BeOfType<NotFoundResult>();
    }
    
    [Test]
    public void DeleteCat_WithValidId_ThenReturnHttpOkWithDeletedCat()
    {
        // Arrange
        var cat = new CatDto(new Guid("8cb35a91-054b-4d1a-902f-5cc5fdf9ee97"), "Tako", 1, 
            "Comun europeo", 5, HealthState.Healthy, new Guid("c785f08a-7d2c-4a8b-abb5-91d0e575fe8b"));
        _mockedCatService.Setup(m => m.Delete(cat.Id)).Returns(cat);
        
        // Act
        var result = _catController.DeleteCat(cat.Id);
        
        // Arrange
        result.Should().BeOfType<OkObjectResult>();
    }
    
    [Test]
    public void CreateCat_WithInvalidId_ThenReturnHttpNotFound()
    {
        // Arrange
        _mockedCatService.Setup(m => m.Delete(Guid.Empty)).Returns(new CatDto());
        
        // Act
        var result = _catController.DeleteCat(Guid.Empty);

        // Assert
        result.Should().BeOfType<NotFoundResult>();
    }
}