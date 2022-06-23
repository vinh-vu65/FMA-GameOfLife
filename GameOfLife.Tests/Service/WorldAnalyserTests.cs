using System.Collections.Generic;
using GameOfLife.Code.Model;
using GameOfLife.Code.Model.ValueObject;
using GameOfLife.Code.Service;
using Xunit;

namespace GameOfLife.Tests.Service;

public class WorldAnalyserTests
{
    private readonly WorldAnalyser _sut;
    private readonly Cell[,] _world;
    private readonly Coordinate _coordinate;

    public WorldAnalyserTests()
    {
        _sut = new WorldAnalyser();
        _world = new World(6, 6).Population;
        _sut.SetDimensions(_world);
        _coordinate = new Coordinate(2, 1);
    }
    
    [Fact]
    public void GetNeighbours_ShouldReturnEightCellCoordinates_WhenGivenCellCoordinates()
    {
        var expectedLength = 8;
        
        var result = _sut.GetNeighbours(_coordinate, _world);
        
        Assert.Equal(expectedLength, result.Count);
    }

    [Fact]
    public void GetNeighbours_ShouldReturnEightOrthogonalCells_WhenGivenCellCoordinatesInMiddleOfWorld()
    {
        var expected = new List<Cell>
        {
            _world[0, 1],
            _world[0, 2],
            _world[0, 3],
            _world[1, 1],
            _world[1, 3],
            _world[2, 1],
            _world[2, 2],
            _world[2, 3]
        };
        
        var result = _sut.GetNeighbours(_coordinate, _world);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetNeighbours_ShouldReturnEightCellsAndWrapAroundToBottomEdge_WhenGivenCellIsOnTopEdgeOfTheWorld()
    {
        var expected = new List<Cell>
        {
            _world[5, 1],
            _world[5, 2],
            _world[5, 3],
            _world[0, 1],
            _world[0, 3],
            _world[1, 1],
            _world[1, 2],
            _world[1, 3]
        };
        
        var result = _sut.GetNeighbours(new Coordinate(2, 0), _world);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetNeighbours_ShouldReturnEightCellsAndWrapAroundToRightEdge_WhenGivenCellIsOnLeftEdgeOfTheWorld()
    {
        var expected = new List<Cell>
        {
            _world[1, 5],
            _world[1, 0],
            _world[1, 1],
            _world[2, 5],
            _world[2, 1],
            _world[3, 5],
            _world[3, 0],
            _world[3, 1]
        };
        
        var result = _sut.GetNeighbours(new Coordinate(0, 2), _world);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetNeighbours_ShouldReturnEightCellsAndWrapAroundEdges_WhenGivenCellIsOnCornerOfTheWorld()
    {
        var expected = new List<Cell>
        {
            _world[5, 5],
            _world[5, 0],
            _world[5, 1],
            _world[0, 5],
            _world[0, 1],
            _world[1, 5],
            _world[1, 0],
            _world[1, 1]
        };
        
        var result = _sut.GetNeighbours(new Coordinate(0,0), _world);
        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CountAliveCells_ShouldReturnNumberOfAliveCells_WhenGivenListOfCells()
    {
        var cellToAdd = new Cell(2, 1)
        {
            IsAlive = true
        };
        var neighbours = new List<Cell>
        {
            cellToAdd,
            cellToAdd,
            cellToAdd,
            new Cell(3,1)
        };
        var expected = 3;

        var result = _sut.CountAliveCells(neighbours);

        Assert.Equal(expected,result);
    }
    
    [Fact]
    public void CountAliveCells_ShouldReturnZero_WhenGivenListOfCellsHaveNoAliveCells()
    {
        var cellToAdd = new Cell(2, 1);
        var neighbours = new List<Cell>
        {
            cellToAdd,
            cellToAdd,
            cellToAdd,
        };
        var expected = 0;

        var result = _sut.CountAliveCells(neighbours);

        Assert.Equal(expected,result);
    }
    
    [Fact]
    public void DetermineNextGeneration_ShouldIncludeCell_WhenGivenCellIsNotAliveAndHasExactlyThreeLiveNeighbours()
    {
        _world[0, 2].IsAlive = true;
        _world[0, 3].IsAlive = true;
        _world[2, 1].IsAlive = true;
        var expected = _world[1, 2].Coordinate;

        var result = _sut.DetermineNextGeneration(_world);

        Assert.Contains(expected, result);
        Assert.Single(result);
    }
    
    [Fact]
    public void DetermineNextGeneration_ShouldIncludeCell_WhenGivenCellIsAliveAndHasTwoLiveNeighbours()
    {
        _world[2, 1].IsAlive = true;
        _world[0, 3].IsAlive = true;
        _world[1, 2].IsAlive = true;
        var expected = _world[1, 2].Coordinate;

        var result = _sut.DetermineNextGeneration(_world);

        Assert.Contains(expected, result);
        Assert.Single(result);
    }
    
    [Fact]
    public void DetermineNextGeneration_ShouldIncludeCell_WhenGivenCellIsAliveAndHasThreeLiveNeighbours()
    {
        _world[1, 2].IsAlive = true;
        _world[0, 2].IsAlive = true;
        _world[0, 3].IsAlive = true;
        _world[2, 1].IsAlive = true;
        var expected = _world[1, 2].Coordinate;
        var expectedLength = 5;

        var result = _sut.DetermineNextGeneration(_world);

        Assert.Contains(expected, result);
        Assert.Equal(expectedLength, result.Count);
    }
}