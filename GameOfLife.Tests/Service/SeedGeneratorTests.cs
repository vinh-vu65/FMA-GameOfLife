using GameOfLife.Code.Service;
using Xunit;

namespace GameOfLife.Tests.Service;

public class SeedGeneratorTests
{
    private readonly SeedGenerator _sut;

    public SeedGeneratorTests()
    {
        _sut = new SeedGenerator();
    }
    
    [Fact]
    public void ReadFile_ShouldReturnStringArray_WhenGivenFilePath()
    {
        var testFilePath = "test.txt";
        var expectedLength = 10;
        
        var result = _sut.ReadFile(testFilePath);
        
        Assert.Equal(expectedLength, result.Length);
    }
}