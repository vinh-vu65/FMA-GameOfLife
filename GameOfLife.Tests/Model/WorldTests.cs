using GameOfLife.Code.Model;
using Xunit;

namespace GameOfLife.Tests.Model;

public class WorldTests
{
    private readonly World _sut;
    private readonly int _rows = 10;
    private readonly int _columns = 15;

    public WorldTests()
    {
        _sut = new World(_rows, _columns);
    }
    
    [Fact]
    public void World_ShouldPopulateWithCells_WhenConstructed()
    {
        var expectedPopulation = 150;
        
        Assert.Equal(_sut.Population.Length, expectedPopulation);
    }
}