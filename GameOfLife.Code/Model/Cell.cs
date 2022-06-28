using GameOfLife.Code.Model.ValueObject;

namespace GameOfLife.Code.Model;

public class Cell
{
    public bool IsAlive { get; set; }
    public Coordinate Coordinate { get; }

    public Cell(int x, int y)
    {
        Coordinate = new Coordinate(x, y);
    }

    public string Display()
    {
        return IsAlive ? "1" : " ";
    }
}