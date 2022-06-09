namespace GameOfLife.Code.Model;

public class Cell
{
    public bool Alive { get; set; }
    public int _x { get; }
    public int _y { get; }

    public Cell(int x, int y)
    {
        _x = x;
        _y = y;
    }
}