using GameOfLife.Code.Model;
using GameOfLife.Code.Model.ValueObject;

namespace GameOfLife.Code.Service;

public class WorldAnalyser : IWorldAnalyser
{
    public List<Coordinate> DetermineNextGeneration(World world)
    {
        var output = new List<Coordinate>();

        for (var i = 0; i < world.Height; i++)
        {
            for (var j = 0; j < world.Width; j++)
            {
                var cell = world.Population[i, j];
                var neighbours = GetNeighbours(cell.Coordinate, world);
                var liveNeighbours = CountAliveCells(neighbours);
                if (cell.IsAlive && liveNeighbours is < 2 or > 3) continue;
                if (!cell.IsAlive && liveNeighbours != 3) continue;

                output.Add(cell.Coordinate);
            }
        }

        return output;
    }
    
    private List<Cell> GetNeighbours(Coordinate cell, World world)
    {
        var neighbours = new List<Cell>();

        var (x, y) = cell;
        for (var i = y-1; i <= y+1; i++)
        {
            for (var j = x-1; j <= x+1; j++)
            {
                var neighbourY = i;
                var neighbourX = j;
                
                if (i == y && j == x) continue;
                if (i < 0) neighbourY = world.Height - 1;
                if (j < 0) neighbourX = world.Width - 1;
                if (i > world.Height - 1) neighbourY = 0;
                if (j > world.Width - 1) neighbourX = 0;
                
                neighbours.Add(world.Population[neighbourY, neighbourX]);
            }
        }

        return neighbours;
    }
    
    private int CountAliveCells(List<Cell> neighbours) => neighbours.Count(x => x.IsAlive);
}