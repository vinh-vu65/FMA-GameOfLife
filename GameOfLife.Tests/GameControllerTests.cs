using GameOfLife.Code;
using Xunit;

namespace GameOfLife.Tests;

public class GameControllerTests
{
    private readonly GameController _sut;

    public GameControllerTests()
    {
        _sut = new GameController();
    }
    
    [Theory]
    [InlineData(10, 10)]
    [InlineData(5, 15)]
    public void CreateGameBoard_ShouldReturnGameBoard_WhenUserInputsSize(int rows, int columns)
    {
        var expected = new GameBoard(rows, columns);

        var result = _sut.CreateGameBoard();
        
        Assert.Equal(expected, result);
    }
}