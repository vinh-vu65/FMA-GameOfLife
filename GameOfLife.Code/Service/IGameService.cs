using GameOfLife.Code.Model;

namespace GameOfLife.Code.Service;

public interface IGameService
{
    World CurrentWorld { get; }
    bool IsWorldStable { get; }
    
    void Tick();
}