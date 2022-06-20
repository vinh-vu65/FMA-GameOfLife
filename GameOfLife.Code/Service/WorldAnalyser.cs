using GameOfLife.Code.Model;

namespace GameOfLife.Code.Service;

public class WorldAnalyser : IWorldAnalyser
{
    private readonly int _maxYValue;
    private readonly int _maxXValue;

    public WorldAnalyser(int rows, int columns)
    {
        _maxXValue = columns - 1;
        _maxYValue = rows - 1;
    }
    
    public List<Cell> DetermineNextGeneration(Cell[,] grid)
    {
        var output = new List<Cell>();
        
        for (var i = 0; i <= _maxYValue; i++)
        {
            for (var j = 0; j <= _maxXValue; j++)
            {
                var cell = grid[i, j];
                var neighbours = GetNeighbours(j, i, grid);
                var liveNeighbours = CountAliveCells(neighbours);
                if (cell.IsAlive && liveNeighbours is < 2 or > 3) continue;
                if (!cell.IsAlive && liveNeighbours != 3) continue;

                output.Add(cell);
            }
        }

        return output;
    }

    public List<Cell> GetNeighbours(int x, int y, Cell[,] grid)
    {
        var output = new List<Cell>();

        for (var i = y-1; i <= y+1; i++)
        {
            for (var j = x-1; j <= x+1; j++)
            {
                var cellY = i;
                var cellX = j;
                
                if (i == y && j == x) continue;
                if (i < 0) cellY = _maxYValue;
                if (j < 0) cellX = _maxXValue;
                if (i > _maxYValue) cellY = 0;
                if (j > _maxXValue) cellX = 0;
                
                output.Add(grid[cellY, cellX]);
            }
        }

        return output;
    }

    public int CountAliveCells(List<Cell> neighbours) => neighbours.Count(x => x.IsAlive);
}