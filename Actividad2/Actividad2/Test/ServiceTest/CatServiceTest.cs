using Actividad2.Domain.Dto;
using Actividad2.Domain.Enum;
using Actividad2.Domain.Generic.Interface;
using Actividad2.Functions;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Actividad2.Test.ServiceTest;

[TestFixture]
public class CatServiceTest
{
    private readonly Mock<IEntityService<Guid, CatDto>> _mockedCatService = new();

    [Test]
    public void Get_ThenReturnsCats()
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
        _mockedCatService.Setup(m => m.Get()).Returns(() => cats);
        
        // Act
        var expectedCats = _mockedCatService.Object.Get();

        // Assert
        expectedCats.Should().BeEquivalentTo(cats);
        expectedCats.Should().BeOfType<List<CatDto>>();
        expectedCats.Should().HaveCount(5);
    }

    [Test]
    public void Get_ThenReturnsNull()
    {
        // Arrange
        _mockedCatService.Setup(m => m.Get()).Returns(() => new List<CatDto>());
        
        // Act
        var expectedCats = _mockedCatService.Object.Get();
        
        // Assert
        ExtensionFunctions.IsNullOrEmpty(expectedCats).Should().BeTrue();
    }

    [Test]
    public void Get_ValidId_ThenReturnsCat()
    {
        // Arrange
        var cat = new CatDto(new Guid("8cb35a91-054b-4d1a-902f-5cc5fdf9ee97"), "Tako", 1, 
            "Comun europeo", 5, HealthState.Healthy, new Guid("c785f08a-7d2c-4a8b-abb5-91d0e575fe8b"));
        _mockedCatService.Setup(m => m.Get(cat.Id)).Returns(cat);
        
        // Act
        var expectedCat = _mockedCatService.Object.Get(cat.Id);
        
        // Assert
        expectedCat.Should().NotBeNull();
        expectedCat.Should().BeOfType<CatDto>();
        expectedCat.Should().BeEquivalentTo(cat);
        expectedCat.Id.Should().Be(cat.Id);
    }
    
    [Test]
    public void Get_InvalidCatId_ThenReturnsNull()
    {
        // Arrange & Act
        _mockedCatService.Setup(m => m.Get(new Guid("8cb35a91-054b-4d1a-902f-5cc5fdf9ee97"))).Returns(null as CatDto);
        
        var receivedCat = _mockedCatService.Object.Get(new Guid("8cb35a91-054b-4d1a-902f-5cc5fdf9ee97"));
        
        // Assert
        receivedCat.Should().BeNull();
    }

    [Test]
    public void Create_ValidCat_ThenReturnsCat()
    {
        // Arrange
        var cat = new CatDto(new Guid("8cb35a91-054b-4d1a-902f-5cc5fdf9ee97"), "Tako", 1, "Comun europeo", 5, HealthState.Healthy, new Guid("c785f08a-7d2c-4a8b-abb5-91d0e575fe8b"));
        _mockedCatService.Setup(m => m.Create(cat)).Returns(cat);
        
        // Act
        var expectedCat = _mockedCatService.Object.Create(cat);
        
        // Assert
        expectedCat.Should().NotBeNull();
        expectedCat.Should().BeOfType<CatDto>();
        expectedCat.Should().BeEquivalentTo(cat);
        expectedCat.Id.Should().Be(cat.Id);
    }
    
    [Test]
    public void Create_InvalidCat_ThenReturnsNull()
    {
        // Arrange & Act
        _mockedCatService.Setup(m => m.Create(new CatDto())).Returns(null as CatDto);
        var receivedCat = _mockedCatService.Object.Create(new CatDto());
        
        // Assert
        receivedCat.Should().BeNull();
    }

    [Test]
    public void Update_ValidCat_ThenReturnsCat()
    {
        // Arrange
        var cat = new CatDto(new Guid("8cb35a91-054b-4d1a-902f-5cc5fdf9ee97"), "Tako", 1, "Comun europeo", 5, HealthState.Healthy, new Guid("c785f08a-7d2c-4a8b-abb5-91d0e575fe8b"));
        _mockedCatService.Setup(m => m.Update(cat)).Returns(cat);
        
        // Act
        var expectedCat = _mockedCatService.Object.Update(cat);
        
        // Assert
        expectedCat.Should().NotBeNull();
        expectedCat.Should().BeOfType<CatDto>();
        expectedCat.Should().BeEquivalentTo(cat);
        expectedCat.Id.Should().Be(cat.Id);
    }

    [Test] public void Update_InvalidCat_ThenReturnsNull()
    {
        // Arrange & Act
        _mockedCatService.Setup(m => m.Update(new CatDto())).Returns(null as CatDto);
        var receivedCat = _mockedCatService.Object.Update(new CatDto());
        
        // Assert
        receivedCat.Should().BeNull();
    }

    [Test]
    public void Delete_ValidCat_ThenReturnsCat()
    {
        // Arrange
        var cat = new CatDto(new Guid("8cb35a91-054b-4d1a-902f-5cc5fdf9ee97"), "Tako", 1, "Comun europeo", 5, HealthState.Healthy, new Guid("c785f08a-7d2c-4a8b-abb5-91d0e575fe8b"));
        _mockedCatService.Setup(m => m.Delete(new Guid("8cb35a91-054b-4d1a-902f-5cc5fdf9ee97"))).Returns(cat);
        
        // Act
        var expectedCat = _mockedCatService.Object.Delete(new Guid("8cb35a91-054b-4d1a-902f-5cc5fdf9ee97"));
        
        // Assert
        expectedCat.Should().NotBeNull();
        expectedCat.Should().BeOfType<CatDto>();
        expectedCat.Should().BeEquivalentTo(cat);
        expectedCat.Id.Should().Be(cat.Id);
    }

    [Test]
    public void Delete_InvalidCat_ThenReturnsNull()
    {
        // Arrange & Act
        _mockedCatService.Setup(m => m.Delete(new Guid())).Returns(null as CatDto);
        var receivedCat = _mockedCatService.Object.Delete(new Guid());
        
        // Assert
        receivedCat.Should().BeNull();
    }
    
}