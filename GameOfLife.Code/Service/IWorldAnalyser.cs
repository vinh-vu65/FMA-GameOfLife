using GameOfLife.Code.Model;

namespace GameOfLife.Code.Service;

public interface IWorldAnalyser
{
    List<Cell> GetNeighbours(int x, int y, Cell[,] grid);
    int CountAliveCells(List<Cell> neighbours);
}