using Code;

namespace Test;

public class DaySeventTest
{
    [Fact]
    public void PartOne_Test()
    {
        var adventOfCode = new DaySeven();

        string input = ".......S.......\n...............\n.......^.......\n...............\n......^.^......\n...............\n.....^.^.^.....\n...............\n....^.^...^....\n...............\n...^.^...^.^...\n...............\n..^...^.....^..\n...............\n.^.^.^.^.^...^.\n...............";
        
        Assert.Equal(21, adventOfCode.PartOne(input));
    }
    
    [Fact]
    public void PartTwo_Test()
    {
        var adventOfCode = new DaySeven();

        string input = ".......S.......\n...............\n.......^.......\n...............\n......^.^......\n...............\n.....^.^.^.....\n...............\n....^.^...^....\n...............\n...^.^...^.^...\n...............\n..^...^.....^..\n...............\n.^.^.^.^.^...^.\n...............";
        
        Assert.Equal(40, adventOfCode.PartTwo(input));
    }

}