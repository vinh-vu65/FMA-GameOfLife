using System.Collections.Generic;
using GameOfLife.Code.Exceptions;
using GameOfLife.Code.IO;
using GameOfLife.Code.Models.DataObjects;
using GameOfLife.Code.Services;
using NSubstitute;
using Xunit;

namespace GameOfLife.Tests.Services;

public class SeedParserTests
{
    private readonly ISeedReader _seedReader = Substitute.For<ISeedReader>();
    
    [Fact]
    public void Constructor_ShouldSetWorldHeightAndWidth_WhenReaderOutputHasAsteriskCharacterInLastElementOfArray()
    {
        var expectedRows = 10;
        var expectedColumns = 5;
        var testFileName = "test";
        var output = new string[]
        {
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "    *"
        };
        _seedReader.Read(testFileName).Returns(output);

        var sut = new SeedFileParser(_seedReader, testFileName);
        
        Assert.Equal(expectedRows, sut.Height);
        Assert.Equal(expectedColumns, sut.Width);
    }
    
    [Fact]
    public void Constructor_ShouldThrowException_WhenLastLineInFileDoesNotContainAsterisk()
    {
        var testFileName = "test";
        var output = new string[]
        {
            "",
            ""
        };
        _seedReader.Read(testFileName).Returns(output);
        
        Assert.Throws<BoundaryNotFoundException>(() => new SeedFileParser(_seedReader, testFileName));
    }

    [Fact]
    public void ParseSeed_ShouldReturnListOfCellsWithCorrespondingCoordinates_WhenGivenFileWithHashtagDenotingLiveCell()
    {
        var testFileName = "test";
        var output = new[]
        {
            "###",
            "",
            "",
            " #",
            "####",
            " #       *"
        };
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
        _seedReader.Read(testFileName).Returns(output);
        var sut = new SeedFileParser(_seedReader, testFileName);

        var result = sut.ParseSeed();
        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ParseSeed_ShouldThrowAnException_WhenGivenFileHasLiveCellWithXValueGreaterThanXValueOfAsterisk()
    {
        var test = "test";
        var output = new string[]
        {
            "     #",
            "  *"
        };
        _seedReader.Read(test).Returns(output);
        var sut = new SeedFileParser(_seedReader, test);

        Assert.Throws<TokenOutOfBoundsException>(() => sut.ParseSeed());
    }
}