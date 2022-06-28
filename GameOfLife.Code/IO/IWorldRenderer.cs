using GameOfLife.Code.Model;

namespace GameOfLife.Code.IO;

public interface IWorldRenderer
{
    string Render(World world);
}