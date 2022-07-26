using GameOfLife.Code.Models;

namespace GameOfLife.Code.IO;

public interface IOutput
{
    void Write(string input);
    void SetColour();
    string RenderWorld(World world);
    void Reset();
}