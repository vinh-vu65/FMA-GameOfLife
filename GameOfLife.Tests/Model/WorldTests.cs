using GameOfLife.Code.Model;
using GameOfLife.Code.Model.ValueObject;
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

    [Theory]
    [InlineData(0,0)]
    [InlineData(12,3)]
    [InlineData(14,9)]
    public void World_ShouldPopulateCellsWithCorrespondingXYValuesInGrid_WhenConstructed(int x, int y)
    {
        var cell = _sut.Population[y, x];
        
        Assert.Equal(x, cell.Coordinate.X);
        Assert.Equal(y, cell.Coordinate.Y);
    }

    [Theory]
    [InlineData(0,0)]
    [InlineData(12,3)]
    [InlineData(14,9)]
    public void GiveCellLife_ShouldChangeIsAlivePropertyOfCellInPopulation_WhenGivenCellCoordinates(int x, int y)
    {
        _sut.GiveLife(new Coordinate(x, y));
        
        Assert.True(_sut.Population[y, x].IsAlive);
    }
}