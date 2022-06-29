using GameOfLife.Code.IO;
using Xunit;

namespace GameOfLife.Tests.IO;

public class SeedFileReaderTests
{
    [Fact]
    public void Read_ShouldReturnAStringArrayCorrespondingToFileLines_WhenConstructorIsGivenAFileNameInSeedsFolder()
    {
        var fileName = "testSeed.txt";
        var sut = new SeedFileReader(fileName);
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

        var result = sut.Read();
        
        Assert.Equal(expected, result);
    }
}