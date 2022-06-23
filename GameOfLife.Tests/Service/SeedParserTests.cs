using System.Collections.Generic;
using GameOfLife.Code.Exceptions;
using GameOfLife.Code.Model;
using GameOfLife.Code.Model.ValueObject;
using GameOfLife.Code.Service;
using Xunit;

namespace GameOfLife.Tests.Service;

public class SeedParserTests
{
    private readonly SeedParser _sut;
    private readonly string _fileName;

    public SeedParserTests()
    {
        _sut = new SeedParser();
        _fileName = "testSeed.txt";
    }
    
    [Fact]
    public void ReadFile_ShouldReturnStringArray_WhenGivenFilePath()
    {
        var expectedLength = 10;
        
        var result = _sut.ReadFile(_fileName);
        
        Assert.Equal(expectedLength, result.Length);
    }

    [Fact]
    public void SetWorldDimensions_ShouldSetRowsAndColumns_WhenTxtFileHasAsteriskCharacterOnBottomRightCorner()
    {
        var expectedRows = 10;
        var expectedColumns = 50;
        var file = _sut.ReadFile(_fileName);

        _sut.SetWorldDimensions(file);
        
        Assert.Equal(expectedRows, _sut.Height);
        Assert.Equal(expectedColumns, _sut.Width);
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
        var file = _sut.ReadFile(_fileName);
        _sut.SetWorldDimensions(file);

        var result = _sut.ParseString(file);
        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ParseString_ShouldThrowAnException_WhenGivenFileHasLiveCellWithXValueGreaterThanXValueOfAsterisk()
    {
        var fileName = "outOfBoundsExceptionTest.txt";
        var file = _sut.ReadFile(fileName);
        _sut.SetWorldDimensions(file);

        Assert.Throws<TokenOutOfBoundsException>(() => _sut.ParseString(file));
    }

    [Fact]
    public void SetWorldDimensions_ShouldThrowException_WhenLastLineInFileDoesNotContainAsterisk()
    {
        var fileName = "boundaryNotFoundExceptionTest.txt";
        var file = _sut.ReadFile(fileName);
        
        Assert.Throws<BoundaryNotFoundException>(() => _sut.SetWorldDimensions(file));
    }
}