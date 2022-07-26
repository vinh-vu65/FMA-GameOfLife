using GameOfLife.Code.Exceptions;
using GameOfLife.Code.IO;
using GameOfLife.Code.Models.DataObjects;

namespace GameOfLife.Code.Services;

public class SeedFileParser : ISeedParser
{
    public int Height { get; private set; }
    public int Width { get; private set; }
    private readonly string[] _seedLines;

    public SeedFileParser(ISeedReader seedReader, string fileName)
    {
        _seedLines = seedReader.Read(fileName);
        SetWorldDimensions(_seedLines);
    }
    
    public List<Coordinate> ParseSeed()
    {
        return ParseString(_seedLines);
    }

    private void SetWorldDimensions(string[] fileLines)
    {
        Height = fileLines.Length;
        var lastLine = fileLines[Height - 1];
        if (!lastLine.Contains('*'))
        {
            throw new BoundaryNotFoundException();
        }
        
        Width = lastLine.IndexOf('*') + 1;
    }

    private List<Coordinate> ParseString(string[] fileLines)
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
                
                var currentToken = row[x];
                if (currentToken == '#')
                {
                    output.Add(new Coordinate(x,y));
                }
            }
        }

        return output;
    }
}