using GameOfLife.Code.Model;
using GameOfLife.Code.Model.ValueObject;

namespace GameOfLife.Code.Service;

public class WorldBuilder
{
    private readonly int _height;
    private readonly int _width;
    
    public WorldBuilder(int height, int width)
    {
        _height = height;
        _width = width;
    }
    
    public Cell[,] CreateWorldPopulation(List<Coordinate> liveCells)
    {
        var world = new World(_height, _width);
        GiveLife(liveCells, world);
        return world.Population;
    }

    private void GiveLife(List<Coordinate> cells, World world)
    {
        foreach (var cell in cells)
        {
            world.GiveLife(cell);
        }
    }
}