using GameOfLife.Code.Model;

namespace GameOfLife.Code.Controller;

public interface IGameService
{
    List<Cell> GetSeed();
}