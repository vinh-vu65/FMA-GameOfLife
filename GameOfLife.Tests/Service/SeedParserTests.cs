using System.Collections.Generic;
using GameOfLife.Code.Exceptions;
using GameOfLife.Code.IO;
using GameOfLife.Code.Model.ValueObject;
using GameOfLife.Code.Service;
using NSubstitute;
using Xunit;

namespace GameOfLife.Tests.Service;

public class SeedParserTests
{
    private readonly ISeedReader _seedReader = Substitute.For<ISeedReader>();
    
    [Fact]
    public void Constructor_ShouldSetWorldHeightAndWidth_WhenReaderOutputHasAsteriskCharacterInLastElementOfArray()
    {
        var expectedRows = 10;
        var expectedColumns = 5;
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
        _seedReader.Read().Returns(output);

        var sut = new SeedFileParser(_seedReader);
        
        Assert.Equal(expectedRows, sut.Height);
        Assert.Equal(expectedColumns, sut.Width);
    }
    
    [Fact]
    public void Constructor_ShouldThrowException_WhenLastLineInFileDoesNotContainAsterisk()
    {
        var output = new string[]
        {
            "",
            ""
        };
        _seedReader.Read().Returns(output);
        
        Assert.Throws<BoundaryNotFoundException>(() => new SeedFileParser(_seedReader));
    }

    [Fact]
    public void
        ParseSeed_ShouldReturnListOfCellsWithCorrespondingCoordinates_WhenGivenFileWithHashtagDenotingLiveCell()
    {
        var output = new string[]
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
        _seedReader.Read().Returns(output);
        var sut = new SeedFileParser(_seedReader);

        var result = sut.ParseSeed();
        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ParseSeed_ShouldThrowAnException_WhenGivenFileHasLiveCellWithXValueGreaterThanXValueOfAsterisk()
    {
        var output = new string[]
        {
            "     #",
            "  *"
        };
        _seedReader.Read().Returns(output);
        var sut = new SeedFileParser(_seedReader);

        Assert.Throws<TokenOutOfBoundsException>(() => sut.ParseSeed());
    }
}