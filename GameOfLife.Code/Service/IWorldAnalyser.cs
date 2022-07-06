using GameOfLife.Code.Model;
using GameOfLife.Code.Model.DataObject;

namespace GameOfLife.Code.Service;

public interface IWorldAnalyser
{
    List<Coordinate>? NextGeneration { get; }
    void DetermineNextGeneration(World world);
    bool IsWorldStable();
}