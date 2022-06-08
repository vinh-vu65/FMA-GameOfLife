using GameOfLife.Code.IO;
using GameOfLife.Code.Model;

namespace GameOfLife.Code.Controller;

public class GameController
{
    private readonly IReader _reader;
    
    public GameController(IReader reader)
    {
        _reader = reader;
    }
    
    public World CreateWorld()
    {
        var rows = int.Parse(_reader.Read());
        var columns = int.Parse(_reader.Read());

        return new World(rows, columns);
    }
}