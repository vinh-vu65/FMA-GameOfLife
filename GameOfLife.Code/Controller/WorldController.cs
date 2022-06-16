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
        GiveLife(aliveCells, output);
        return output;
    }

    private void GiveLife(List<Cell> cells, World world)
    {
        foreach (var cell in cells)
        {
            world.GiveCellLife(cell.X, cell.Y);
        }
    }

    public List<Cell> DetermineNextGeneration(Cell[,] grid)
    {
        var output = new List<Cell>();
        
        for (var i = 0; i < _rows; i++)
        {
            for (var j = 0; j < _columns; j++)
            {
                var cell = grid[i, j];
                var neighbours = _analyser.GetNeighbours(j, i, grid);
                var liveNeighbours = _analyser.CountAliveCells(neighbours);
                if (cell.IsAlive && liveNeighbours is < 2 or > 3) continue;
                if (!cell.IsAlive && liveNeighbours != 3) continue;

                output.Add(cell);
            }
        }

        return output;
    }
}