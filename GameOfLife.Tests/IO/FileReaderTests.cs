using GameOfLife.Code.IO;
using Xunit;

namespace GameOfLife.Tests.IO;

public class FileReaderTests
{
    [Fact]
    public void Read_ShouldReturnAStringArrayCorrespondingToFileLines_WhenConstructorIsGivenAFileNameInSeedsFolder()
    {
        var fileName = "testSeed.txt";
        var sut = new FileReader(fileName);
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