using GameOfLife.Code.Model.ValueObject;

namespace GameOfLife.Code.Service;

public interface ISeedParser
{
    List<Coordinate> ParseSeed();
}