using GameOfLife.Code.Controller;
using GameOfLife.Code.IO;
using GameOfLife.Code.Model;
using NSubstitute;
using Xunit;


namespace GameOfLife.Tests.Controller;

public class GameControllerTests
{
    private readonly GameController _sut;
    private readonly IReader _reader = Substitute.For<IReader>();

    public GameControllerTests()
    {
        _sut = new GameController(_reader);
    }
    
    [Theory]
    [InlineData(10, 10)]
    [InlineData(5, 15)]
    public void CreateGameBoard_ShouldReturnGameBoard_WhenUserInputsSize(int rows, int columns)
    {
        var expected = new GameBoard(rows, columns);
        _reader.Read().Returns($"{rows}", $"{columns}");

        var result = _sut.CreateGameBoard();
        
        Assert.Equal(expected.Rows, result.Rows);
        Assert.Equal(expected.Columns, result.Columns);
    }
}