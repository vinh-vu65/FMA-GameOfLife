using GameOfLife.Code.Model;
using GameOfLife.Code.Model.ValueObject;

namespace GameOfLife.Code.Service;

public interface IWorldAnalyser
{
    List<Coordinate> DetermineNextGeneration(Cell[,] population);
}