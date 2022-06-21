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
}