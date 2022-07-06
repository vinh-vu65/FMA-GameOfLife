using System.Text;

namespace GameOfLife.Code.IO;

public static class GameMessageBuilder
{
    public static string StartupMessage()
    {
        return "Welcome to Conway's Game Of Life!\n";
    }

    public static string ChooseSeed(string[] seedFiles)
    {
        var sb = new StringBuilder();
        sb.Append("Please choose a seed file to load\n");
        for (var i = 0; i < seedFiles.Length; i++)
        {
            sb.Append($"{i + 1}. {seedFiles[i]}\n");
        }

        sb.Append($"Enter a number from [1 - {seedFiles.Length}]: ");

        return sb.ToString();
    }

    public static string ChooseSpeed()
    {
        var sb = new StringBuilder();
        sb.Append("\nPlease set the speed for the simulations to run\n");
        sb.Append("1. Slow\n2. Regular\n3. Fast\n4. No Delay\n");
        sb.Append("Enter a number from [1 - 4]: ");

        return sb.ToString();
    }

    public static string ChooseRepetitions()
    {
        var sb = new StringBuilder();
        sb.Append("\nPlease choose the maximum number of generations you would like to simulate\n");
        sb.Append("The simulation will run for your selected number of generations or until the world has stabilised\n");
        sb.Append("Please enter a number: ");

        return sb.ToString();
    }

    public static string InvalidInput()
    {
        return "Please enter a valid number: ";
    }

    public static string DisplayGeneration(int generation)
    {
        return $"Generation: {generation}";
    }

    public static string SimulationEnded()
    {
        return "Simulation has ended!";
    }

    public static string WorldStabilised(int generation)
    {
        return $"The world has stabilised at generation {generation}.";
    }
}