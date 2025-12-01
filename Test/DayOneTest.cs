using Code;

namespace Test;

public class DayOneTest
{
    [Fact]
    public void DayOneExample_Test()
    {
        var adventOfCode = new DayOne();

        List<string> rotations = 
        [
            "L68", "L30", "R48", "L5", "R60", "L55", "L1", "L99", "R14", "L82"
        ];
        
        Assert.Equal(3, adventOfCode.PartOne(rotations));
    }
    
    [Fact]
    public void DayOneExamplePartTwo_Test()
    {
        var adventOfCode = new DayOne();

        List<string> rotations = 
        [
            "L68", "L30", "R48", "L5", "R60", "L55", "L1", "L99", "R14", "L82"
        ];
        
        Assert.Equal(6, adventOfCode.PartTwo(rotations));
    }
}