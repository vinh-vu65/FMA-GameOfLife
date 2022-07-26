using GameOfLife.Code.Enums;
using GameOfLife.Code.IO;
using GameOfLife.Code.Services;

namespace GameOfLife.Code.ServiceManagers;

public class Application
{
    private readonly IOutput _output;
    private readonly IGameService _gameService;
    private readonly GameSpeed _gameSpeed;
    private readonly int _generationLimit;

    public Application(IOutput output, IGameService gameService, GameSpeed gameSpeed, int generationLimit) 
    {
        _output = output;
        _gameService = gameService;
        _gameSpeed = gameSpeed;
        _generationLimit = generationLimit;
    }

    public void Run()
    {
        var generation = 1;
        _output.SetColour();
        while (generation <= _generationLimit && !_gameService.IsWorldStable)
        {
            PrintWorldAndTick(generation);
            if (_gameService.IsWorldStable) break;
            GameSpeedDelay();
            generation++;
        }
        if (_gameService.IsWorldStable) _output.Write(GameMessageBuilder.WorldStabilised(generation));
        _output.Write(GameMessageBuilder.SimulationEnded());
    }
    
    private void GameSpeedDelay()
    {
        Thread.Sleep((int) _gameSpeed);
    }

    private void PrintWorldAndTick(int generation)
    {
        var renderedWorld = _output.RenderWorld(_gameService.CurrentWorld);
        _output.Reset();
        _output.Write(GameMessageBuilder.DisplayGeneration(generation));
        _output.Write(renderedWorld);
        _gameService.Tick();
    }
}