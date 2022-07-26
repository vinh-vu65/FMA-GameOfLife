using GameOfLife.Code.Models;
using Xunit;

namespace GameOfLife.Tests.Models;

public class CellTests
{
    [Fact]
    public void Display_ShouldReturn1AsString_WhenCellIsAlive()
    {
        var sut = new Cell(0,0)
        {
            IsAlive = true
        };
        var expected = "1";

        var result = sut.Display();
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void Display_ShouldReturnAFullStop_WhenCellIsNotAlive()
    {
        var sut = new Cell(0,0)
        {
            IsAlive = false
        };
        var expected = ".";

        var result = sut.Display();
        
        Assert.Equal(expected, result);
    }
}