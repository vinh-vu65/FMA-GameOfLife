using GameOfLife.Code.Service;
using Xunit;

namespace GameOfLife.Tests.Service;

public class WorldAnalyserTests
{
    private readonly WorldAnalyser _sut;

    public WorldAnalyserTests(WorldAnalyser sut)
    {
        _sut = sut;
    }
    
    [Fact]
    public void GetOrthogonalCells_ShouldReturnEightCellCoordinates_WhenGivenCell()
    {
        var expectedLength = 8;
        var result = _sut.GetOrthogonalCells();
        
        Assert.Equal(expectedLength, result.Length);
    }
}