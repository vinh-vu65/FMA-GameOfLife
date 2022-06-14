using GameOfLife.Code.Model;

namespace GameOfLife.Code.Service;

public class WorldAnalyser
{
    private Cell[,] World { get; set; } = null!;
    private readonly int _maxYValue;
    private readonly int _maxXValue;

    public WorldAnalyser(int rows, int columns)
    {
        _maxXValue = columns - 1;
        _maxYValue = rows - 1;
    }

    public void SetWorld(Cell[,] world)
    {
        World = world;
    }
    
    public List<Cell> GetNeighbours(int x, int y)
    {
        var output = new List<Cell>();
        
        var upperY = y - 1;
        var lowerY = y + 1;
        var leftX = x - 1;
        var rightX = x + 1;

        upperY = upperY < 0 ? _maxYValue : upperY;
        leftX = leftX < 0 ? _maxXValue : leftX;
        upperY = upperY > _maxYValue ? 0 : upperY;
        rightX = rightX > _maxXValue ? 0 : rightX;
        
        output.Add(World[upperY, leftX]);
        output.Add(World[upperY, x]);
        output.Add(World[upperY, rightX]);
        output.Add(World[y, leftX]);
        output.Add(World[y, rightX]);
        output.Add(World[lowerY, leftX]);
        output.Add(World[lowerY, x]);
        output.Add(World[lowerY, rightX]);

        return output;
    }
}