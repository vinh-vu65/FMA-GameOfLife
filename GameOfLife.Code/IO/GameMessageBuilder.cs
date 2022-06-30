using System.Reflection;
using System.Text;

namespace GameOfLife.Code.IO;

public static class GameMessageBuilder
{
    public static string StartupMessage()
    {
        return "Welcome to Conway's Game Of Life!";
    }

    public static string ChooseSeed()
    {
        var seedFiles = GetSeedFileNames();
        var sb = new StringBuilder();
        sb.Append($"Please choose a seed file to load, enter a number from [1 - {seedFiles.Length}:\n");
        for (var i = 0; i < seedFiles.Length; i++)
        {
            sb.Append($"{i + 1}. {seedFiles[i]}\n");
        }

        return sb.ToString();
    }

    public static string ChooseSpeed()
    {
        var sb = new StringBuilder();
        sb.Append("Please set the speed for the simulations to run, enter a number from [1 - 4]:");
        sb.Append("1. Slow\n2. Regular\n3. Fast\n 4. No Delay");

        return sb.ToString();
    }

    private static string[] GetSeedFileNames()
    {
        var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "Seeds");
        var d = new DirectoryInfo(path);
        var fileArray = d.GetFiles();

        return fileArray.Select(x => x.Name).ToArray();
    }
}