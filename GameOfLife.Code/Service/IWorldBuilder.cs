using GameOfLife.Code.Model;
using GameOfLife.Code.Model.DataObject;

namespace GameOfLife.Code.Service;

public interface IWorldBuilder
{
    World BuildWorld(List<Coordinate> liveCells);
}