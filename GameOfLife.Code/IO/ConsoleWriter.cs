namespace GameOfLife.Code.IO;

public class ConsoleWriter : IWriter
{
    public void Write(string input)
    {
        Console.WriteLine(input);
    }
}