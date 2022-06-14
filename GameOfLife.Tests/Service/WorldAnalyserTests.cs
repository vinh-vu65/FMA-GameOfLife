using GameOfLife.Code.Model;
using GameOfLife.Code.Service;
using Xunit;

namespace GameOfLife.Tests.Service;

public class WorldAnalyserTests
{
    private readonly WorldAnalyser _sut;
    private readonly Cell[,] _world;

    public WorldAnalyserTests()
    {
        _sut = new WorldAnalyser(6, 6);
        _world = new World(6, 6).Population;
        _sut.SetWorld(_world);
    }
    
    [Fact]
    public void GetNeighbours_ShouldReturnEightCellCoordinates_WhenGivenCellCoordinates()
    {
        var expectedLength = 8;
        var result = _sut.GetNeighbours(2,1);
        
        Assert.Equal(expectedLength, result.Count);
    }
}