using GameOfLife.Code.Models;
using GameOfLife.Code.Models.DataObjects;

namespace GameOfLife.Code.Services;

public interface IWorldBuilder
{
    World BuildWorld(List<Coordinate> liveCells);
}