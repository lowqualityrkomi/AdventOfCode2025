namespace Code;

public class DayTwo
{
    public Int128 PartOne(string ranges)
    {
        Int128 count = 0;
        List<string> rangesList = ranges.Split(',').ToList();
        
        rangesList.ForEach(range =>
        {
            List<string> rangeStartEnd = range.Split('-').ToList();
            string start = rangeStartEnd[0];
            string end = rangeStartEnd[1];

            for (Int128 i = Int128.Parse(start); i <= Int128.Parse(end); i++)
            {
                if (CheckInvalid($"{i}"))
                {
                    count += i;
                }
            }

        });

        return count;
    }

    private bool CheckInvalid(string value)
    {
        if (value.Substring(0, value.Length / 2) == value.Substring(value.Length / 2))
        {
            return true;
        }

        return false;
    }
}