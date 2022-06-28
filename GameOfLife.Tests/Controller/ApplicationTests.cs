using GameOfLife.Code.Controller;
using GameOfLife.Code.IO;
using GameOfLife.Code.Model;
using NSubstitute;
using Xunit;

namespace GameOfLife.Tests.Controller;

public class ApplicationTests
{
    private readonly Application _sut;
    private readonly IWorldRenderer _renderer = Substitute.For<IWorldRenderer>();
    private readonly IWriter _writer = Substitute.For<IWriter>();
    private readonly IGameService _gameService = Substitute.For<IGameService>();

    public ApplicationTests()
    {
        _sut = new Application(_writer, _gameService, _renderer);
    }

    [Fact]
    public void Run_ShouldRenderWorldWriteRenderedWorldAndTickGameService()
    {
        _sut.Run(1);
        
        _writer.Received().Write(Arg.Any<string>());
        _renderer.Received().Render(Arg.Any<World>());
        _gameService.Received().Tick();
    }
    
    [Fact]
    public void Run_ShouldRepeatServiceMethodCalls_WhenGivenNumberOfTimesToRepeat()
    {
        var timesToRepeat = 3;
        _sut.Run(timesToRepeat);
        
        _writer.Received(timesToRepeat).Write(Arg.Any<string>());
        _renderer.Received(timesToRepeat).Render(Arg.Any<World>());
        _gameService.Received(timesToRepeat).Tick();
    }
}