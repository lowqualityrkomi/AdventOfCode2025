namespace Code;

public class DayFive
{
    public Int64 PartOne(string input)
    {
        Int64 count = 0;

        string[] rows = input.Split('\n');
        int index = 0;
        List<string> freshIds = new List<string>();

        while (!string.IsNullOrEmpty(rows[index]))
        {
            freshIds.Add(rows[index]);
            index++;
        }

        index++;

        for (int i = index; i < rows.Length; i++)
        {
            if (!string.IsNullOrEmpty(rows[i]))
            {
                Int64 ingredient = Int64.Parse(rows[i]);

                for (int j = 0; j < freshIds.Count; j++)
                {
                    string[] ids = freshIds[j].Split('-');
                    Int64 start = Int64.Parse(ids[0]);
                    Int64 end = Int64.Parse(ids[1]);

                    if (start <= ingredient && end >= ingredient)
                    {
                        count++;
                        break;
                    }
                }
            }
        }

        return count;
    }

    public Int64 PartTwo(string input)
    {
        string[] rows = input.Split('\n');
        var ranges = new List<(long Start, long End)>();
        int index = 0;
        
        while (index < rows.Length && !string.IsNullOrWhiteSpace(rows[index]))
        {
            string[] parts = rows[index].Split('-');

            long start = long.Parse(parts[0]);
            long end   = long.Parse(parts[1]);
            
            if (start > end)
                (start, end) = (end, start);

            ranges.Add((start, end));
            index++;
        }

        if (ranges.Count == 0)
            return 0;
        
        ranges.Sort((a, b) => a.Start.CompareTo(b.Start));

        long total = 0;

        long currentStart = ranges[0].Start;
        long currentEnd   = ranges[0].End;

        for (int i = 1; i < ranges.Count; i++)
        {
            var r = ranges[i];
            
            if (r.Start <= currentEnd + 1)
            {
                if (r.End > currentEnd)
                    currentEnd = r.End;
            }
            else
            {
                total += currentEnd - currentStart + 1;
                
                currentStart = r.Start;
                currentEnd   = r.End;
            }
        }
        
        total += currentEnd - currentStart + 1;

        return total;
    }
}