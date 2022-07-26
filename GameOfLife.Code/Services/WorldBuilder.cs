using GameOfLife.Code.Models;
using GameOfLife.Code.Models.DataObjects;

namespace GameOfLife.Code.Services;

public class WorldBuilder : IWorldBuilder
{
    private readonly int _height;
    private readonly int _width;
    
    public WorldBuilder(int height, int width)
    {
        _height = height;
        _width = width;
    }
    
    public World BuildWorld(List<Coordinate> liveCells)
    {
        var world = new World(_height, _width);
        GiveLife(liveCells, world);
        return world;
    }

    private void GiveLife(List<Coordinate> cells, World world)
    {
        foreach (var cell in cells)
        {
            world.GiveLife(cell);
        }
    }
}