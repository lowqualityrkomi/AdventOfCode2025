using Code;

namespace Test;

public class DayFourTest
{
    [Fact]
    public void PartOne_Test()
    {
        var adventOfCode = new DayFour();

        string input =
            "..@@.@@@@.\n@@@.@.@.@@\n@@@@@.@.@@\n@.@@@@..@.\n@@.@@@@.@@\n.@@@@@@@.@\n.@.@.@.@@@\n@.@@@.@@@@\n.@@@@@@@@.\n@.@.@@@.@.";
        
        Assert.Equal(13, adventOfCode.PartOne(input));
    }
}