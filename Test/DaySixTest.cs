using Code;

namespace Test;

public class DaySixTest
{
    [Fact]
    public void PartOne_Test()
    {
        var adventOfCode = new DaySix();

        string input = "123 328  51 64 \n 45 64  387 23 \n  6 98  215 314\n*   +   *   + ";
        
        Assert.Equal(4277556, adventOfCode.PartOne(input));
    }
    
    [Fact]
    public void PartTwo_Test()
    {
        var adventOfCode = new DaySix();

        string input = "123 328  51 64 \n 45 64  387 23 \n  6 98  215 314\n*   +   *   + ";
        
        Assert.Equal(3263827, adventOfCode.PartTwo(input));
    }
}