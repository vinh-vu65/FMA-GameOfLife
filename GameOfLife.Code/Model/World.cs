using GameOfLife.Code.Model.ValueObject;

namespace GameOfLife.Code.Model;

public class World
{
    public Cell[,] Population { get; }
    public int Height { get; }
    public int Width { get; }

    public World(int height, int width)
    {
        Height = height;
        Width = width;
        Population = new Cell[height,width];
        PopulateWorld(height, width);
    }

    private void PopulateWorld(int height, int width)
    {
        for (var i = 0; i < height ; i++)
        {
            for (var j = 0; j < width; j++)
            {
                Population[i, j] = new Cell(j, i);
            }
        }
    }

    public void GiveLife(Coordinate cellCoordinate)
    {
        Population[cellCoordinate.Y, cellCoordinate.X].IsAlive = true;
    }
}