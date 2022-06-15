namespace GameOfLife.Code.Model;

public class World
{
    public int Rows { get; }
    public int Columns { get; }
    public Cell[,] Population { get; }

    public World(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        Population = new Cell[rows,columns];
        PopulateWorld(Rows, Columns);
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

    public void SetCellToAlive(int x, int y)
    {
        Population[y, x].IsAlive = true;
    }
    
    public void SetCellToDead(int x, int y)
    {
        Population[y, x].IsAlive = false;
    }
}