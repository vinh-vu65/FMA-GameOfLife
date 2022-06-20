using System.Collections.Generic;
using GameOfLife.Code.Model;
using GameOfLife.Code.Service;
using NSubstitute;
using Xunit;

namespace GameOfLife.Tests.Controller;

public class WorldBuilderTests
{
    private readonly WorldBuilder _sut;
    private readonly int _rows = 6;
    private readonly int _columns = 6;

    public WorldBuilderTests()
    {
        _sut = new WorldBuilder(_rows, _columns);
    }
    
    [Theory]
    [InlineData(10, 10)]
    [InlineData(5, 15)]
    public void CreateWorldPopulation_ShouldReturnWorldGridOfGivenDimensions_WhenDimensionsAreGivenInConstructor(int rows, int columns)
    {
        var sut = new WorldBuilder(rows, columns);
        var emptyList = new List<Cell>();
        
        var result = sut.CreateWorldPopulation(emptyList);
        
        Assert.Equal(rows, result.GetLength(0));
        Assert.Equal(columns, result.GetLength(1));
    }

    [Fact]
    public void CreateWorldPopulation_ShouldChangeGivenCellsToAliveInOutput_WhenGivenListOfCells()
    {
        var cellsList = new List<Cell>
        {
            new(2, 1),
            new(3, 2),
            new(0, 0)
        };

        var result = _sut.CreateWorldPopulation(cellsList);

        Assert.True(result[1,2].IsAlive);
        Assert.True(result[2,3].IsAlive);
        Assert.True(result[0,0].IsAlive);
        Assert.False(result[5,5].IsAlive);
    }
}