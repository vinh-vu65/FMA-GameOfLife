using GameOfLife.Code.IO;
using Xunit;

namespace GameOfLife.Tests.IO;

public class GameMessageBuilderTests
{
    [Fact]
    public void ChooseSeed_ShouldOutputStringWhichIncludesAllItemsInArray_WhenGivenStringArray()
    {
        var fileNames = new[] {"hello", "this", "is", "a", "test"};
        var expected = "Please choose a seed file to load\n1. hello\n2. this\n3. is\n4. a\n5. test\n" +
                       "Enter a number from [1 - 5]: ";

        var result = GameMessageBuilder.ChooseSeed(fileNames);
        
        Assert.Equal(expected, result);
    }
}