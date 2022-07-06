using System.Collections.Generic;
using GameOfLife.Code.Model;
using GameOfLife.Code.Model.DataObject;
using GameOfLife.Code.Service;
using Xunit;

namespace GameOfLife.Tests.Service;

public class WorldAnalyserTests
{
    private readonly WorldAnalyser _sut;
    private readonly World _world;

    public WorldAnalyserTests()
    {
        _sut = new WorldAnalyser(new List<Coordinate>());
        _world = new World(6, 6);
    }

    [Fact]
    public void DetermineNextGeneration_ShouldIncludeCell_WhenGivenCellIsNotAliveAndHasExactlyThreeLiveNeighbours()
    {
        _world.Population[0, 2].IsAlive = true;
        _world.Population[0, 3].IsAlive = true;
        _world.Population[2, 1].IsAlive = true;
        var expected = _world.Population[1, 2].Coordinate;

        _sut.DetermineNextGeneration(_world);

        Assert.Contains(expected, _sut.NextGeneration!);
        Assert.Single(_sut.NextGeneration!);
    }
    
    [Fact]
    public void DetermineNextGeneration_ShouldIncludeCell_WhenGivenCellIsAliveAndHasTwoLiveNeighbours()
    {
        _world.Population[2, 1].IsAlive = true;
        _world.Population[0, 3].IsAlive = true;
        _world.Population[1, 2].IsAlive = true;
        var expected = _world.Population[1, 2].Coordinate;

        _sut.DetermineNextGeneration(_world);

        Assert.Contains(expected, _sut.NextGeneration!);
        Assert.Single(_sut.NextGeneration!);
    }
    
    [Fact]
    public void DetermineNextGeneration_ShouldIncludeCell_WhenGivenCellIsAliveAndHasThreeLiveNeighbours()
    {
        _world.Population[1, 2].IsAlive = true;
        _world.Population[0, 2].IsAlive = true;
        _world.Population[0, 3].IsAlive = true;
        _world.Population[2, 1].IsAlive = true;
        var expected = _world.Population[1, 2].Coordinate;
        var expectedLength = 5;

        _sut.DetermineNextGeneration(_world);

        Assert.Contains(expected, _sut.NextGeneration!);
        Assert.Equal(expectedLength, _sut.NextGeneration!.Count);
    }

    [Fact]
    public void IsWorldStable_ShouldReturnTrue_WhenCurrentGenerationIsEqualToNextGeneration()
    {
        var seed = new List<Coordinate>
        {
            new(0, 0),
            new(1, 0),
            new(3, 0),
            new(4, 0),
            new(0, 1),
            new(1, 1),
            new(3, 1),
            new(4, 1)
        };
        var world = new WorldBuilder(10, 10).BuildWorld(seed);
        var sut = new WorldAnalyser(seed);
        sut.DetermineNextGeneration(world);

        var result = sut.IsWorldStable();
        
        Assert.True(result);
    }
    
    [Fact]
    public void IsWorldStable_ShouldReturnFalse_WhenCurrentGenerationIsNotEqualToNextGeneration()
    {
        var seed = new List<Coordinate>
        {
            new(2, 0),
            new(1, 0),
            new(3, 0),
            new(4, 0),
            new(2, 1),
            new(1, 1),
            new(3, 1),
            new(4, 1)
        };
        var world = new WorldBuilder(10, 10).BuildWorld(seed);
        var sut = new WorldAnalyser(seed);
        sut.DetermineNextGeneration(world);

        var result = sut.IsWorldStable();
        
        Assert.False(result);
    }
}