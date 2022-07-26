using GameOfLife.Code.Models;

namespace GameOfLife.Code.Services;

public interface IGameService
{
    World CurrentWorld { get; }
    bool IsWorldStable { get; }
    
    void Tick();
}