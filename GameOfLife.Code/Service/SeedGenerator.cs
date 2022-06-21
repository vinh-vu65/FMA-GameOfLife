using GameOfLife.Code.Model;

namespace GameOfLife.Code.Service;

public class SeedGenerator
{
    public int Rows { get; private set; }
    public int Columns { get; private set; }
    
    public string[] ReadFile(string filePath)
    {
        return File.ReadAllLines($"../../../{filePath}");
    }

    public void SetWorldDimensions(string[] seed)
    {
        Rows = seed.Length;
        var lastLine = seed[Rows - 1];
        Columns = lastLine.IndexOf('*') + 1;
    }

    public List<Coordinate> ParseString(string[] seed)
    {
        var output = new List<Coordinate>();
        for (var y = 0; y < Rows; y++)
        {
            var line = seed[y];
            for (var x = 0; x < line.Length; x++)
            {
                var token = line[x];
                if (token == '#')
                {
                    output.Add(new(x,y));
                }
            }
        }

        return output;
    }
}