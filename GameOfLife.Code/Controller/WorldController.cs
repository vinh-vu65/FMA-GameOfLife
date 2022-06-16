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

    private void BringCellsToLife(List<Cell> cells, World world)
    {
        foreach (var cell in cells)
        {
            world.SetCellToAlive(cell.X, cell.Y);
        }
    }

    public List<Cell> DetermineNextGeneration(Cell[,] world)
    {
        var output = new List<Cell>();
        var rows = world.GetLength(0);
        var columns = world.GetLength(1);
        for (var i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                var neighbours = _analyser.GetNeighbours(j, i, world);
                var liveNeighbours = _analyser.CountAliveCells(neighbours);
                if (!world[i,j].IsAlive && liveNeighbours != 3) continue;
                
                output.Add(world[i,j]);
            }
        }

        return output;
    }
}