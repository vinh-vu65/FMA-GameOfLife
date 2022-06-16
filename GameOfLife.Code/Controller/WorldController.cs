using GameOfLife.Code.IO;
using GameOfLife.Code.Model;
using GameOfLife.Code.Service;

namespace GameOfLife.Code.Controller;

public class WorldController
{
    private readonly int _rows;
    private readonly int _columns;
    private readonly WorldAnalyser _analyser;
    
    public WorldController(int rows, int columns)
    {
        _rows = rows;
        _columns = columns;
        _analyser = new WorldAnalyser(rows, columns);
    }
    
    public World CreateWorld(List<Cell> aliveCells)
    {
        var output = new World(_rows, _columns);
        BringCellsToLife(aliveCells, output);
        return output;
    }

    public void BringCellsToLife(List<Cell> cells, World world)
    {
        foreach (var cell in cells)
        {
            world.SetCellToAlive(cell.X, cell.Y);
        }
    }
}