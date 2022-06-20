using System.Collections.Generic;
using GameOfLife.Code.Controller;
using GameOfLife.Code.Model;
using GameOfLife.Code.Service;
using NSubstitute;
using Xunit;


namespace GameOfLife.Tests.Controller;

public class WorldControllerTests
{
    private readonly WorldController _sut;
    private readonly IWorldAnalyser _analyser = Substitute.For<IWorldAnalyser>();
    private readonly int _rows = 6;
    private readonly int _columns = 6;

    public WorldControllerTests()
    {
        _sut = new WorldController(_rows, _columns, _analyser);
    }
    
    [Theory]
    [InlineData(10, 10)]
    [InlineData(5, 15)]
    public void CreateWorldPopulation_ShouldReturnWorldGridOfGivenDimensions_WhenDimensionsAreGivenInConstructor(int rows, int columns)
    {
        var sut = new WorldController(rows, columns, _analyser);
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

    [Fact]
    public void DetermineNextGeneration_ShouldIncludeCell_WhenGivenCellIsNotAliveAndHasExactlyThreeLiveNeighbours()
    {
        var world = _sut.CreateWorldPopulation(new List<Cell>());
        var neighbours = new List<Cell>
        {
            new(1, 1)
        };
        _analyser.GetNeighbours(2, 1, world).Returns(neighbours);
        _analyser.CountAliveCells(neighbours).Returns(3);
        var expected = world[1, 2];

        var result = _sut.DetermineNextGeneration(world);

        Assert.Contains(expected, result);
        Assert.Single(result);
    }
    
    [Fact]
    public void DetermineNextGeneration_ShouldIncludeCell_WhenGivenCellIsAliveAndHasTwoLiveNeighbours()
    {
        var liveCell = new List<Cell>
        {
            new(2, 1) {IsAlive = true}
        };
        var world = _sut.CreateWorldPopulation(liveCell);
        var neighbours = new List<Cell>
        {
            new(1, 1)
        };
        _analyser.GetNeighbours(2, 1, world).Returns(neighbours);
        _analyser.CountAliveCells(neighbours).Returns(2);
        var expected = world[1, 2];

        var result = _sut.DetermineNextGeneration(world);

        Assert.Contains(expected, result);
        Assert.Single(result);
    }
    
    [Fact]
    public void DetermineNextGeneration_ShouldIncludeCell_WhenGivenCellIsAliveAndHasThreeLiveNeighbours()
    {
        var liveCell = new List<Cell>
        {
            new(2, 1) {IsAlive = true}
        };
        var world = _sut.CreateWorldPopulation(liveCell);
        var neighbours = new List<Cell>
        {
            new(1, 1)
        };
        _analyser.GetNeighbours(2, 1, world).Returns(neighbours);
        _analyser.CountAliveCells(neighbours).Returns(3);
        var expected = world[1, 2];

        var result = _sut.DetermineNextGeneration(world);

        Assert.Contains(expected, result);
        Assert.Single(result);
    }
}