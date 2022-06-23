using GameOfLife.Code.Model.ValueObject;

namespace GameOfLife.Code.Model;

public class World
{
    public Cell[,] Population { get; }

    public World(int rows, int columns)
    {
        Population = new Cell[rows,columns];
        PopulateWorld(rows, columns);
    }

    private void PopulateWorld(int rows, int columns)
    {
        for (var i = 0; i < rows ; i++)
        {
            for (var j = 0; j < columns; j++)
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