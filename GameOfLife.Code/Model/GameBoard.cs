namespace GameOfLife.Code.Model;

public class GameBoard
{
    public int Rows { get; }
    public int Columns { get; }

    public GameBoard(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
    }
}