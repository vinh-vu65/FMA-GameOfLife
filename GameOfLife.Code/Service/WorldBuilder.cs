using GameOfLife.Code.Model;
using GameOfLife.Code.Model.ValueObject;

namespace GameOfLife.Code.Service;

public class WorldBuilder
{
    private readonly int _rows;
    private readonly int _columns;
    
    public WorldBuilder(int rows, int columns)
    {
        _rows = rows;
        _columns = columns;
    }
    
    public Cell[,] CreateWorldPopulation(List<Coordinate> liveCells)
    {
        var world = new World(_rows, _columns);
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