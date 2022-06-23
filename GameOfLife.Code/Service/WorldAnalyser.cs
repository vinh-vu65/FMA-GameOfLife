using GameOfLife.Code.Model;
using GameOfLife.Code.Model.ValueObject;

namespace GameOfLife.Code.Service;

public class WorldAnalyser : IWorldAnalyser
{
    private int _height;
    private int _width;

    public List<Coordinate> DetermineNextGeneration(Cell[,] population)
    {
        var output = new List<Coordinate>();

        SetDimensions(population);
        
        for (var i = 0; i < _height; i++)
        {
            for (var j = 0; j < _width; j++)
            {
                var cell = population[i, j];
                var neighbours = GetNeighbours(cell.Coordinate, population);
                var liveNeighbours = CountAliveCells(neighbours);
                if (cell.IsAlive && liveNeighbours is < 2 or > 3) continue;
                if (!cell.IsAlive && liveNeighbours != 3) continue;

                output.Add(cell.Coordinate);
            }
        }

        return output;
    }
    
    public void SetDimensions(Cell[,] population)
    {
        _height = population.GetLength(0);
        _width = population.GetLength(1);
    }

    public List<Cell> GetNeighbours(Coordinate cell, Cell[,] population)
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
                if (i < 0) neighbourY = _height - 1;
                if (j < 0) neighbourX = _width - 1;
                if (i > _height - 1) neighbourY = 0;
                if (j > _width - 1) neighbourX = 0;
                
                neighbours.Add(population[neighbourY, neighbourX]);
            }
        }

        return neighbours;
    }
    
    public int CountAliveCells(List<Cell> neighbours) => neighbours.Count(x => x.IsAlive);
}