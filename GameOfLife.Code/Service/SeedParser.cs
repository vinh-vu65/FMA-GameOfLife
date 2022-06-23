using System.Reflection;
using GameOfLife.Code.Exceptions;
using GameOfLife.Code.Model;
using GameOfLife.Code.Model.ValueObject;

namespace GameOfLife.Code.Service;

public class SeedParser
{
    public int Height { get; private set; }
    public int Width { get; private set; }
    
    public string[] ReadFile(string fileName)
    {
        var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "Seeds", fileName);
        return File.ReadAllLines(path);
    }

    public void SetWorldDimensions(string[] fileLines)
    {
        Height = fileLines.Length;
        var lastLine = fileLines[Height - 1];
        if (!lastLine.Contains('*'))
        {
            throw new BoundaryNotFoundException();
        }
        
        Width = lastLine.IndexOf('*') + 1;
    }

    public List<Coordinate> ParseString(string[] fileLines)
    {
        var output = new List<Coordinate>();
        for (var y = 0; y < Height; y++)
        {
            var row = fileLines[y];
            for (var x = 0; x < row.Length; x++)
            {
                if (row.Length > Width)
                {
                    throw new TokenOutOfBoundsException(y);
                }
                
                var token = row[x];
                if (token == '#')
                {
                    output.Add(new(x,y));
                }
            }
        }

        return output;
    }
}