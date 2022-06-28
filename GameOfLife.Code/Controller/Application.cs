using GameOfLife.Code.IO;

namespace GameOfLife.Code.Controller;

public class Application
{
    private readonly IWriter _writer;
    private readonly IGameService _gameService;
    private readonly IWorldRenderer _renderer;

    public Application(IWriter writer, IGameService gameService, IWorldRenderer renderer)
    {
        _writer = writer;
        _gameService = gameService;
        _renderer = renderer;
    }

    public void Run(int generationLimit)
    {
        var generation = 1;
        Console.ForegroundColor = ConsoleColor.Green;
        while (generation <= generationLimit)
        {
            var renderedWorld = _renderer.Render(_gameService.CurrentWorld);
            Console.Clear();
            _writer.Write(renderedWorld);
            _gameService.Tick();
            Thread.Sleep(1000);
            generation++;
        }
    }
}