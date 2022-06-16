using System.Collections.Generic;
using GameOfLife.Code.Controller;
using GameOfLife.Code.Model;
using Xunit;


namespace GameOfLife.Tests.Controller;

public class WorldControllerTests
{
    private readonly WorldController _sut;
    private readonly int _rows = 6;
    private readonly int _columns = 6;

    public WorldControllerTests()
    {
        _sut = new WorldController(_rows, _columns);
    }
    
    [Theory]
    [InlineData(10, 10)]
    [InlineData(5, 15)]
    public void CreateWorld_ShouldReturnWorldGridOfGivenDimensions_WhenDimensionsAreGivenInConstructor(int rows, int columns)
    {
        var sut = new WorldController(rows, columns);
        var emptyList = new List<Cell>();
        
        var result = sut.CreateWorld(emptyList);
        
        Assert.Equal(rows, result.Population.GetLength(0));
        Assert.Equal(columns, result.Population.GetLength(1));
    }

    [Fact]
    public void CreateWorld_ShouldChangeGivenCellsToAliveInWorldOutput_WhenGivenListOfCells()
    {
        var cellsList = new List<Cell>
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