using GameOfLife.Code.Model;
using GameOfLife.Code.Service;

namespace GameOfLife.Code.Controller;

public class GameService : IGameService
{
    private readonly IWorldAnalyser _worldAnalyser;
    private readonly IWorldBuilder _worldBuilder;
    private readonly ISeedParser _seedParser;
    public World CurrentWorld { get; private set; } = null!;

    public GameService(ISeedParser seedParser, IWorldAnalyser worldAnalyser, IWorldBuilder worldBuilder)
    {
        _seedParser = seedParser;
        _worldAnalyser = worldAnalyser;
        _worldBuilder = worldBuilder;
        Initialise();
    }
    
    private void Initialise()
    {
        var seed = _seedParser.ParseSeed();
        CurrentWorld = _worldBuilder.BuildWorld(seed);
    }

    public void Tick()
    {
        var nextGeneration = _worldAnalyser.DetermineNextGeneration(CurrentWorld);
        CurrentWorld = _worldBuilder.BuildWorld(nextGeneration);
    }
}