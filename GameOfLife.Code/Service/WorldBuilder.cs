using GameOfLife.Code.Model;

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
    
    public Cell[,] CreateWorldPopulation(List<Cell> aliveCells)
    {
        var world = new World(_rows, _columns);
        GiveLife(aliveCells, world);
        return world.Population;
    }

    private void GiveLife(List<Cell> cells, World world)
    {
        foreach (var cell in cells)
        {
            world.GiveCellLife(cell.X, cell.Y);
        }
    }
}