namespace GameOfLife.Code.IO;

public class ConsoleInput : IInput
{
    public string Read()
    {
        return Console.ReadLine()!;
    }
}