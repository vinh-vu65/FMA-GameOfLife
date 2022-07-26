using GameOfLife.Code.Models;

namespace GameOfLife.Code.IO;

public interface IWorldRenderer
{
    string Render(World world);
}