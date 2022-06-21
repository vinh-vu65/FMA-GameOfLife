namespace GameOfLife.Code.Service;

public class SeedGenerator
{
    public string[] ReadFile(string filePath)
    {
        return File.ReadAllLines($"../../../{filePath}");
    }
    
    
}