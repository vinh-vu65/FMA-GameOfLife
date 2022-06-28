using System.Text;
using GameOfLife.Code.Model;

namespace GameOfLife.Code.IO;

public class ConsoleRenderer : IWorldRenderer
{
    public string Render(World world)
    {
        var horizontalBorder = new string('⎯', world.Width + 1);
        var verticalBorderChar = '|';
        
        var sb = new StringBuilder();
        
        sb.Append(horizontalBorder);
        sb.Append('\n');
        for (var y = 0; y < world.Height; y++)
        {
            sb.Append(verticalBorderChar);
            for (var x = 0; x < world.Width; x++)
            {
                var cell = world.Population[y, x];
                sb.Append(cell.Display());
            }
            sb.Append(verticalBorderChar);
            sb.Append('\n');
        }

        sb.Append(horizontalBorder);
        
        return sb.ToString();
    }
}