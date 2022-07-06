using GameOfLife.Code.Controller;
using GameOfLife.Code.Enums;
using GameOfLife.Code.IO;
using GameOfLife.Code.Model;
using GameOfLife.Code.Service;
using NSubstitute;
using Xunit;

namespace GameOfLife.Tests.Controller;

public class ApplicationTests
{
    private readonly IOutput _output = Substitute.For<IOutput>();
    private readonly IGameService _gameService = Substitute.For<IGameService>();
    private GameSpeed _instantGameSpeed = GameSpeed.NoDelay;

    [Fact]
    public void Run_ShouldRenderPrintAndTickWorld()
    {
        var world = new World(3, 3);
        var renderedWorld = "hello I am a rendered world";
        _output.RenderWorld(world).Returns(renderedWorld);
        _gameService.CurrentWorld.Returns(world);
        _gameService.IsWorldStable.Returns(false);
        var sut = new Application(_output, _gameService, _instantGameSpeed, 1);
        
        sut.Run();

        _output.Received(1).RenderWorld(_gameService.CurrentWorld);
        _output.Received(1).Write(renderedWorld);
        _gameService.Received(1).Tick();
    }

    [Fact]
    public void Run_ShouldRepeatServiceCalls_WhenGivenTimesToRepeatInConstructor()
    {
        var timesToRepeat = 10;
        var world = new World(3, 3);
        var renderedWorld = "hello I am a rendered world";
        _output.RenderWorld(world).Returns(renderedWorld);
        _gameService.CurrentWorld.Returns(world);
        _gameService.IsWorldStable.Returns(false);
        var sut = new Application(_output, _gameService, _instantGameSpeed, timesToRepeat);
        
        sut.Run();

        _output.Received(timesToRepeat).RenderWorld(_gameService.CurrentWorld);
        _output.Received(timesToRepeat).Write(renderedWorld);
        _gameService.Received(timesToRepeat).Tick();
    }

    [Fact]
    public void Run_ShouldPrintSimulationFinishedMessage_WhenSimulationHasRunForMaxGenerations()
    {
        _gameService.IsWorldStable.Returns(false);
        var sut = new Application(_output, _gameService, _instantGameSpeed, 1);

        sut.Run();
        
        _output.Received(1).Write(GameMessageBuilder.SimulationEnded());
    }

    [Fact]
    public void Run_ShouldBreakLoopAndPrintWorldStabilisedMessage_WhenWorldHasStabilised()
    {
        _gameService.IsWorldStable.Returns(true);
        var sut = new Application(_output, _gameService, _instantGameSpeed, 100);

        sut.Run();
        
        _gameService.DidNotReceive().Tick();
        _output.Received(1).Write(GameMessageBuilder.WorldStabilised(1));
        _output.Received(1).Write(GameMessageBuilder.SimulationEnded());
    }
}