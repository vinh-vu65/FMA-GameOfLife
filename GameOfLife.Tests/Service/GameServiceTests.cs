using System.Collections.Generic;
using GameOfLife.Code.Model;
using GameOfLife.Code.Model.DataObject;
using GameOfLife.Code.Service;
using NSubstitute;
using Xunit;

namespace GameOfLife.Tests.Service;

public class GameServiceTests
{
    private readonly IWorldAnalyser _analyser = Substitute.For<IWorldAnalyser>();
    private readonly IWorldBuilder _builder = Substitute.For<IWorldBuilder>();
    private readonly List<Coordinate> _seed;

    public GameServiceTests()
    {
        _seed = new List<Coordinate>
        {
            new(0, 0),
        };
    }

    [Fact]
    public void GameService_ShouldUpdateCurrentWorldWithNewWorldWithLiveCellsBasedOnSeed_WhenConstructed()
    {
        var testWorld = new World(6, 6);
        _builder.BuildWorld(_seed).Returns(testWorld);
        
        var sut = new GameService(_seed, _analyser, _builder);

        Assert.Equal(testWorld, sut.CurrentWorld);
    }

    [Fact]
    public void Tick_ShouldCallWorldAnalyserToDetermineNextGenerationBasedOnCurrentWorld()
    {
        var sut = new GameService(_seed, _analyser, _builder);
        
        sut.Tick();

        _analyser.Received(1).DetermineNextGeneration(sut.CurrentWorld);
    }

    [Fact]
    public void Tick_ShouldUpdateCurrentWorldBasedOnWorldAnalyserNextGeneration()
    {
        var nextGeneration = new List<Coordinate>
        {
            new(0, 0),
            new(1, 1)
        };
        _analyser.NextGeneration.Returns(nextGeneration);
        var testWorld = new World(6, 6);
        _builder.BuildWorld(nextGeneration).Returns(testWorld);
        var sut = new GameService(_seed, _analyser, _builder);

        sut.Tick();
        
        Assert.Equal(testWorld, sut.CurrentWorld);
    }

    [Fact]
    public void IsStable_ShouldCallWorldAnalyserIsWorldStableMethod()
    {
        var sut = new GameService(_seed, _analyser, _builder);

        var testCall = sut.IsWorldStable;

        _analyser.Received(1).IsWorldStable();
    }
}