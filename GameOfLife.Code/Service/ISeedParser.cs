using GameOfLife.Code.Model.DataObject;

namespace GameOfLife.Code.Service;

public interface ISeedParser
{
    List<Coordinate> ParseSeed();
}