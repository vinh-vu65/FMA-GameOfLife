using System.Collections.Generic;
using GameOfLife.Code.Model;
using GameOfLife.Code.Model.ValueObject;
using GameOfLife.Code.Service;
using NSubstitute;
using Xunit;

namespace GameOfLife.Tests.Controller;

public class WorldBuilderTests
{
    private readonly WorldBuilder _sut;
    private readonly int _height = 6;
    private readonly int _width = 6;

    public WorldBuilderTests()
    {
        _sut = new WorldBuilder(_height, _width);
    }
    
    [Theory]
    [InlineData(10, 10)]
    [InlineData(5, 15)]
    public void CreateWorldPopulation_ShouldReturnWorldGridOfGivenDimensions_WhenDimensionsAreGivenInConstructor(int height, int width)
    {
        var sut = new WorldBuilder(height, width);
        var emptyList = new List<Coordinate>();
        
        var result = sut.CreateWorld(emptyList);
        
        Assert.Equal(height, result.Height);
        Assert.Equal(width, result.Width);
    }

    [Fact]
    public void CreateWorldPopulation_ShouldChangeGivenCellsToAliveInOutput_WhenGivenListOfCells()
    {
        var cellsList = new List<Coordinate>
        {
            new(2, 1),
            new(3, 2),
            new(0, 0)
        };

        var result = _sut.CreateWorld(cellsList);

        Assert.True(result.Population[1,2].IsAlive);
        Assert.True(result.Population[2,3].IsAlive);
        Assert.True(result.Population[0,0].IsAlive);
        Assert.False(result.Population[5,5].IsAlive);
    }
}