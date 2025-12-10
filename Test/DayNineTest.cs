using Code;

namespace Test;

public class DayNineTest
{
    [Fact]
    public void PartOne_Test()
    {
        var adventOfCode = new DayNine();

        string input = "7,1\n11,1\n11,7\n9,7\n9,5\n2,5\n2,3\n7,3";
        
        Assert.Equal(50, adventOfCode.PartOne(input));
    }
    
    [Fact]
    public void PartTwo_Test()
    {
        var adventOfCode = new DayNine();

        string input = "7,1\n11,1\n11,7\n9,7\n9,5\n2,5\n2,3\n7,3";
        
        Assert.Equal(24, adventOfCode.PartTwo(input));
    }
}