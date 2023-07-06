namespace GameOfLife.Code.Model;

public class Cell
{
    public bool Alive { get; set; }
    public int X { get; }
    public int Y { get; }

    public Cell(int x, int y)
    {
        X = x;
        Y = y;
    }
}