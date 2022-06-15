using System.Collections.Generic;
using GameOfLife.Code.Controller;
using GameOfLife.Code.IO;
using GameOfLife.Code.Model;
using NSubstitute;
using Xunit;


namespace GameOfLife.Tests.Controller;

public class WorldControllerTests
{
    private readonly WorldController _sut;
    private readonly IReader _reader = Substitute.For<IReader>();

    public WorldControllerTests()
    {
        _sut = new WorldController(_reader);
        _reader.Read().Returns("6");
    }
    
    [Theory]
    [InlineData(10, 10)]
    [InlineData(5, 15)]
    public void CreateWorld_ShouldReturnWorldGrid_WhenUserInputsSize(int rows, int columns)
    {
        var expected = new World(rows, columns);
        _reader.Read().Returns($"{rows}", $"{columns}");
        
        var result = _sut.CreateWorld();
        
        Assert.Equal(expected.Rows, result.Rows);
        Assert.Equal(expected.Columns, result.Columns);
    }

    [Fact]
    public void BringCellsToLife_ShouldChangeAllCellsToAlive_WhenGivenListOfCellsAndWorld()
    {
        var world = _sut.CreateWorld();
        var cellsList = new List<Cell>
        {
            new(2, 1),
            new(3, 2),
            new(0, 0)
        };
        
        _sut.BringCellsToLife(cellsList, world);
        
        Assert.True(world.Population[1,2].IsAlive);
        Assert.True(world.Population[2,3].IsAlive);
        Assert.True(world.Population[0,0].IsAlive);
    }
}