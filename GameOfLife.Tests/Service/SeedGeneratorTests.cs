using System.Collections.Generic;
using GameOfLife.Code.Model;
using GameOfLife.Code.Service;
using Xunit;

namespace GameOfLife.Tests.Service;

public class SeedGeneratorTests
{
    private readonly SeedGenerator _sut;
    private readonly string _filePath;

    public SeedGeneratorTests()
    {
        _sut = new SeedGenerator();
        _filePath = "test.txt";
    }
    
    [Fact]
    public void ReadFile_ShouldReturnStringArray_WhenGivenFilePath()
    {
        var expectedLength = 10;
        
        var result = _sut.ReadFile(_filePath);
        
        Assert.Equal(expectedLength, result.Length);
    }

    [Fact]
    public void SetWorldDimensions_ShouldSetRowsAndColumns_WhenTxtFileHasAsteriskCharacterOnBottomRightCorner()
    {
        var expectedRows = 10;
        var expectedColumns = 50;
        var file = _sut.ReadFile(_filePath);

        _sut.SetWorldDimensions(file);
        
        Assert.Equal(expectedRows, _sut.Rows);
        Assert.Equal(expectedColumns, _sut.Columns);
    }

    [Fact]
    public void
        ParseString_ShouldReturnListOfCellsWithCorrespondingCoordinates_WhenGivenFileWithHashtagDenotingLiveCell()
    {
        var expected = new List<Coordinate>
        {
            new(0,0),
            new(1,0),
            new(2,0),
            new(1,3),
            new(0,4),
            new(1,4),
            new(2,4),
            new(3,4),
            new(1,5)
        };
        var file = _sut.ReadFile(_filePath);
        _sut.SetWorldDimensions(file);

        var result = _sut.ParseString(file);
        
        Assert.Equal(expected, result);
    }
}