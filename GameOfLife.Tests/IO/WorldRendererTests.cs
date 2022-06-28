using GameOfLife.Code.IO;
using GameOfLife.Code.Model;
using Xunit;

namespace GameOfLife.Tests.IO;

public class WorldRendererTests
{
    [Fact]
    public void Render_ShouldReturnStringDisplayingEachCellAndBordersAroundWorld_WhenGivenWorld()
    {
        var sut = new WorldRenderer();
        var testWorld = new World(4, 4);
        testWorld.Population[3, 3].IsAlive = true;
        testWorld.Population[1, 1].IsAlive = true;
        var expected = "⎯⎯⎯⎯⎯\n|....|\n|.1..|\n|....|\n|...1|\n⎯⎯⎯⎯⎯";

        var result = sut.Render(testWorld);
        
        Assert.Equal(expected, result);
    }
}