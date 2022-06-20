using GameOfLife.Code.IO;

namespace GameOfLife.Code.Controller;

public class Application
{
    private readonly IReader _reader;
    private readonly IWriter _writer;
    private IGameService _gameService;

    public Application(IReader reader, IWriter writer, IGameService gameService)
    {
        _reader = reader;
        _writer = writer;
        _gameService = gameService;
    }

    public void Setup()
    {
        _gameService.GetSeed();
    }
}