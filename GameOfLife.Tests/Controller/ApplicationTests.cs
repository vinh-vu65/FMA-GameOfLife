using GameOfLife.Code.Controller;
using GameOfLife.Code.IO;
using NSubstitute;
using Xunit;

namespace GameOfLife.Tests.Controller;

public class ApplicationTests
{
    private readonly Application _sut;
    private readonly IReader _reader = Substitute.For<IReader>();
    private readonly IWriter _writer = Substitute.For<IWriter>();
    private readonly IGameService _gameService = Substitute.For<IGameService>();

    public ApplicationTests()
    {
        _sut = new Application(_reader, _writer, _gameService);
    }

    [Fact]
    public void Setup_ShouldCallGameServiceGetSeedMethod()
    {
        _sut.Setup();

        _gameService.Received(1).GetSeed();
    }
}