using GameOfLife.Code.Models;
using GameOfLife.Code.Models.DataObjects;

namespace GameOfLife.Code.Services;

public class GameService : IGameService
{
    private readonly IWorldAnalyser _worldAnalyser;
    private readonly IWorldBuilder _worldBuilder;
    public World CurrentWorld { get; private set; }
    public bool IsWorldStable => _worldAnalyser.IsWorldStable();

    public GameService(List<Coordinate> seed, IWorldAnalyser worldAnalyser, IWorldBuilder worldBuilder)
    {
        _worldAnalyser = worldAnalyser;
        _worldBuilder = worldBuilder;
        CurrentWorld = _worldBuilder.BuildWorld(seed);
    }

    public void Tick()
    {
        _worldAnalyser.DetermineNextGeneration(CurrentWorld);
        CurrentWorld = _worldBuilder.BuildWorld(_worldAnalyser.NextGeneration!);
    }
}