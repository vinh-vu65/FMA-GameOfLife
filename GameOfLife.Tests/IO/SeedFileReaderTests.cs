using System.Collections.Generic;
using GameOfLife.Code.IO;
using Xunit;

namespace GameOfLife.Tests.IO;

public class SeedFileReaderTests
{
    private readonly string _seedsFolder = "TestSeeds";
    
    [Fact]
    public void Read_ShouldReturnAStringArrayCorrespondingToFileLines_WhenGivenAFileNameInSeedsFolder()
    {
        var fileName = "testSeed.txt";
        var sut = new SeedFileReader(_seedsFolder);
        var expected = new[]
        {
            "###",
            "",
            "",
            " #",
            "####",
            " #",
            "    *"
        };

        var result = sut.Read(fileName);
        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetFilenames_ShouldReturnArrayOfFileNamesInSeedsFolderInAlphabeticalOrder()
    {
        var sut = new SeedFileReader(_seedsFolder);
        var expected = new[]
        {
            "abc.txt",
            "hello.txt",
            "testSeed.txt"
        };
        
        var result = sut.GetFilenames();
        
        Assert.Equal(expected[0], result[0]);
        Assert.Equal(expected[1], result[1]);
        Assert.Equal(expected[2], result[2]);
    }
    
    [Fact]
    public void
        SeedFileReader_ShouldCreateAMenuWithSeedFilesInAlphabeticalOrderAndNumbersCountingFromOne_WhenConstructed()
    {
        var expected = new Dictionary<string, string>
        {
            {"1", "abc.txt"},
            {"2", "hello.txt"},
            {"3", "testSeed.txt"}
        };

        var sut = new SeedFileReader(_seedsFolder);
        
        Assert.Equal(expected["1"], sut.SeedFilesMenu["1"]);
        Assert.Equal(expected["2"], sut.SeedFilesMenu["2"]);
        Assert.Equal(expected["3"], sut.SeedFilesMenu["3"]);
    }
}