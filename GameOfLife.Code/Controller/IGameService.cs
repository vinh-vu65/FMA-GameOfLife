using GameOfLife.Code.Model;
using GameOfLife.Code.Model.ValueObject;

namespace GameOfLife.Code.Controller;

public interface IGameService
{
    World CurrentWorld { get; }
    
    void Tick();
}