using Code;

namespace Test;

public class DayThreeTest
{
    [Fact]
    public void PartOne_Test()
    {
        var adventOfCode = new DayThree();

        var banks = "987654321111111\n811111111111119\n234234234234278\n818181911112111";
        
        Assert.Equal(357, adventOfCode.PartOne(banks, 2));
    }
    
    [Fact]
    public void PartTwo_Test()
    {
        var adventOfCode = new DayThree();

        var banks = "987654321111111\n811111111111119\n234234234234278\n818181911112111";
        
        Assert.Equal(3121910778619, adventOfCode.PartOne(banks, 12));
    }
}