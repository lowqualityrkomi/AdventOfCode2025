namespace Code;

public class DayOne
{
    public int PartOne(List<string> rotations)
    {
        int position = 50;
        int counter = 0;
        
        rotations.ForEach(rotation =>
        {
            var rotateTo = Int32.Parse(rotation.Substring(1));
            var direction = rotation.Substring(0, 1);
            var delta = direction == "L" ? -1 : 1;
            
            position += rotateTo * delta;

            if (position % 100 == 0)
            {
                counter++;
                position %= 100;
            }
            else if (position < 0)
            {
                position += 100;
            }
        });
        
        return counter;
    }

    public int PartTwo(List<string> rotations)
    {
        int position = 50;
        int counter = 0;
        
        rotations.ForEach(rotation =>
        {
            var rotateTo = Int32.Parse(rotation.Substring(1));
            var direction = rotation.Substring(0, 1);
            var delta = direction == "L" ? -1 : 1;

            for (int i = 0; i < rotateTo; i++)
            {
                position += delta;
                if (position % 100 == 0)
                {
                    counter++;
                    position %= 100;
                }
                if (position < 0)
                {
                    position += 100;
                }
            }
        });
        
        return counter;
    }
}