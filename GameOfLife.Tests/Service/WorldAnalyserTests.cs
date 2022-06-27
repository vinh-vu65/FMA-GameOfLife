using GameOfLife.Code.Model;
using GameOfLife.Code.Service;
using Xunit;

namespace GameOfLife.Tests.Service;

public class WorldAnalyserTests
{
    private readonly WorldAnalyser _sut;
    private readonly Cell[,] _world;

    public WorldAnalyserTests()
    {
        _sut = new WorldAnalyser();
        _world = new World(6, 6).Population;
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