using GameOfLife.Code.Models.DataObjects;

namespace GameOfLife.Code.Models;

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
        return IsAlive ? "1" : ".";
    }
}