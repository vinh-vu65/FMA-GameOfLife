using GameOfLife.Code.IO;
using GameOfLife.Code.Model;

namespace GameOfLife.Code.Controller;

public class WorldController
{
    private readonly IReader _reader;
    public World World { get; private set; } = null!;
    
    public WorldController(IReader reader)
    {
        _reader = reader;
    }
    
    public void CreateWorld()
    {
        var rows = int.Parse(_reader.Read());
        var columns = int.Parse(_reader.Read());

        World = new World(rows, columns);
    }
    
    
}