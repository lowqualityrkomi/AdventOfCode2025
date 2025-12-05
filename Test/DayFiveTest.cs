using Code;

namespace Test;

public class DayFiveTest
{
    [Fact]
    public void PartOne_Test()
    {
        var adventOfCode = new DayFive();

        string input = "3-5\n10-14\n16-20\n12-18\n\n1\n5\n8\n11\n17\n32";
        
        Assert.Equal(3, adventOfCode.PartOne(input));
    }
    
    [Fact]
    public void PartTwo_Test()
    {
        var adventOfCode = new DayFive();

        string input = "3-5\n10-14\n16-20\n12-18\n\n1\n5\n8\n11\n17\n32";
        
        Assert.Equal(14, adventOfCode.PartTwo(input));
    }
}