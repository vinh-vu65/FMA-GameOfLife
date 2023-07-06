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
    
    public GameBoard CreateGameBoard()
    {
        var boardRows = int.Parse(_reader.Read());
        var boardColumns = int.Parse(_reader.Read());

        return new GameBoard(boardRows, boardColumns);
    }
}