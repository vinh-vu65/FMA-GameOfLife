using System.Collections.Generic;
using GameOfLife.Code.Controller;
using GameOfLife.Code.Model;
using GameOfLife.Code.Model.ValueObject;
using GameOfLife.Code.Service;
using NSubstitute;
using Xunit;

namespace GameOfLife.Tests.Controller;

public class GameServiceTests
{
    private readonly ISeedParser _seedParser = Substitute.For<ISeedParser>();
    private readonly IWorldAnalyser _analyser = Substitute.For<IWorldAnalyser>();
    private readonly IWorldBuilder _builder = Substitute.For<IWorldBuilder>();
    
    
    [Fact]
    public void GameService_ShouldCallSeedParserToCreateSeed_WhenConstructed()
    {
        var sut = new GameService(_seedParser, _analyser, _builder);

        _seedParser.Received(1).ParseSeed();
    }

    [Fact]
    public void GameService_ShouldUpdateCurrentWorldWithNewWorldWithLiveCellsBasedOnSeed_WhenConstructed()
    {
        var seed = new List<Coordinate>
        {
            new(0, 0),
            new(1, 2),
            new(1, 3),
            new(2, 2)
        };
        _seedParser.ParseSeed().Returns(seed);
        var expected = new World(6, 6);
        _builder.BuildWorld(seed).Returns(expected);
        
        var sut = new GameService(_seedParser, _analyser, _builder);

        Assert.Equal(expected, sut.CurrentWorld);
    }

    [Fact]
    public void Tick_ShouldCallWorldAnalyserToDetermineNextGenerationBasedOnCurrentWorld()
    {
        var sut = new GameService(_seedParser, _analyser, _builder);
        
        sut.Tick();

        _analyser.Received(1).DetermineNextGeneration(sut.CurrentWorld);
    }

    [Fact]
    public void Tick_ShouldUpdateCurrentWorldBasedOnWorldAnalyserDetermineNextGeneration()
    {
        var nextGeneration = new List<Coordinate>
        {
            new(0, 0),
            new(1, 1)
        };
        _analyser.DetermineNextGeneration(Arg.Any<World>()).Returns(nextGeneration);
        var expected = new World(6, 6);
        _builder.BuildWorld(nextGeneration).Returns(expected);
        var sut = new GameService(_seedParser, _analyser, _builder);

        sut.Tick();
        
        Assert.Equal(expected, sut.CurrentWorld);
    }
}