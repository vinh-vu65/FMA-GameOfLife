using GameOfLife.Code.Model;

namespace GameOfLife.Code.Service;

public interface IWorldAnalyser
{
    List<Cell> DetermineNextGeneration(Cell[,] grid);
}