using GameOfLife.Code.Models.DataObjects;

namespace GameOfLife.Code.Services;

public interface ISeedParser
{
    List<Coordinate> ParseSeed();
}