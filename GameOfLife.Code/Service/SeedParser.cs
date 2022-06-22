using System.Reflection;
using GameOfLife.Code.Exceptions;
using GameOfLife.Code.Model;

namespace GameOfLife.Code.Service;

public class SeedParser
{
    public int Rows { get; private set; }
    public int Columns { get; private set; }
    
    public string[] ReadFile(string fileName)
    {
        string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $@"Seeds/{fileName}");
        return File.ReadAllLines(path);
    }

    public void SetWorldDimensions(string[] seed)
    {
        Rows = seed.Length;
        var lastLine = seed[Rows - 1];
        if (!lastLine.Contains('*'))
        {
            throw new BoundaryNotFoundException();
        }
        
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
                if (line.Length > Columns)
                {
                    throw new TokenOutOfBoundsException(y);
                }
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