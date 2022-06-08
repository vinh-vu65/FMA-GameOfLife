namespace GameOfLife.Code.Model;

public class World
{
    public int Rows { get; }
    public int Columns { get; }

    public World(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
    }
}