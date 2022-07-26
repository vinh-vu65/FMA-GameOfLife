using System.Collections.Generic;
using System.Configuration;
using GameOfLife.Code.IO;
using Xunit;

namespace GameOfLife.Tests.IO;

public class SeedFileReaderTests
{
    private readonly string _testSeedsFolder = "TestSeeds";
    private readonly SeedFileReader _sut;

    public SeedFileReaderTests()
    {
        ConfigurationManager.AppSettings.Set("seedsFolder", _testSeedsFolder);
        _sut = new SeedFileReader();
    }
    
    [Fact]
    public void Read_ShouldReturnAStringArrayCorrespondingToFileLines_WhenGivenAFileNameInSeedsFolder()
    {
        var fileName = "testSeed.txt";
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

        var result = _sut.Read(fileName);
        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetFilenames_ShouldReturnArrayOfFileNamesInSeedsFolderInAlphabeticalOrder()
    {
        var expected = new[]
        {
            "abc.txt",
            "hello.txt",
            "testSeed.txt"
        };
        
        var result = _sut.GetFilenames();
        
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
        
        Assert.Equal(expected["1"], _sut.SeedFilesMenu["1"]);
        Assert.Equal(expected["2"], _sut.SeedFilesMenu["2"]);
        Assert.Equal(expected["3"], _sut.SeedFilesMenu["3"]);
    }
}