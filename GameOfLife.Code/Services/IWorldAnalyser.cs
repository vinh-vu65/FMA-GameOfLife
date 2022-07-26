using GameOfLife.Code.Models;
using GameOfLife.Code.Models.DataObjects;

namespace GameOfLife.Code.Services;

public interface IWorldAnalyser
{
    List<Coordinate>? NextGeneration { get; }
    void DetermineNextGeneration(World world);
    bool IsWorldStable();
}