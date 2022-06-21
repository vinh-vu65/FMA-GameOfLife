using GameOfLife.Code.Service;

var seed = new SeedGenerator();
var lines = seed.ReadFile("test.txt");
foreach (var line in lines)
{
    Console.WriteLine(line);
}