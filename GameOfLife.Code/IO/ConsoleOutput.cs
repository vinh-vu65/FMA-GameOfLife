using GameOfLife.Code.Model;

namespace GameOfLife.Code.IO;

public class ConsoleOutput : IOutput
{
    private readonly IWorldRenderer _renderer;

    public ConsoleOutput(IWorldRenderer renderer)
    {
        _renderer = renderer;
    }

    public void Write(string input)
    {
        Console.WriteLine(input);
    }

    public void SetColour()
    {
        Console.ForegroundColor = ConsoleColor.Green;
    }

    public string RenderWorld(World world)
    {
        return _renderer.Render(world);
    }

    public void Reset()
    {
        Console.Clear();
    }
}