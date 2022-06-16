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

    public void GiveCellLife(int x, int y)
    {
        Population[y, x].IsAlive = true;
    }
}