namespace Code;

public class DaySeven
{
    public int PartOne(string input)
    {
        int counter = 0;
        char[][] matrix = input
            .Split('\n')
            .Select(line => line.Trim()) 
            .Where(line => !string.IsNullOrEmpty(line)) 
            .Select(line => line.ToCharArray())
            .ToArray();

        for (int j = 0; j < matrix[0].Length; j++)
        {
            if (matrix[0][j] == 'S')
            {
                matrix[1][j] = '|';
            }
        }

        for (int row = 1; row < matrix.GetLength(0); row++)
        {
            for (int cell = 0; cell < matrix[row].Length; cell++)
            {
                if (matrix[row][cell] == '^' && matrix[row - 1][cell] == '|')
                {
                    counter++;
                    matrix[row][cell - 1] = '|';
                    matrix[row][cell + 1] = '|';
                }
                else if (matrix[row][cell] == '.' && matrix[row - 1][cell] == '|')
                {
                    matrix[row][cell] = '|';
                }
            }
        }

        return counter;
    }
    
    public long PartTwo(string input)
    {
        var lines = input
            .Split('\n')
            .Select(line => line.Trim())
            .Where(line => !string.IsNullOrEmpty(line) && (line.Contains('S') || line.Contains('^')))
            .ToArray();

        int rows = lines.Length;
        if (rows == 0) return 0;

        int cols = lines[0].Length;
        
        char[][] matrix = new char[rows][];
        for (int r = 0; r < rows; r++)
        {
            matrix[r] = lines[r].ToCharArray();
        }
        
        long[] counts = new long[cols];
        
        for (int j = 0; j < cols; j++)
        {
            if (matrix[0][j] == 'S')
            {
                counts[j]++;
            }
        }

        for (int row = 1; row < rows; row++)
        {
            long[] nextCounts = new long[cols];

            for (int col = 0; col < cols; col++)
            {
                long currentCount = counts[col];
                if (currentCount == 0)
                    continue;

                if (matrix[row][col] == '^')
                {
                    if (col - 1 >= 0)
                        nextCounts[col - 1] += currentCount;

                    if (col + 1 < cols)
                        nextCounts[col + 1] += currentCount;
                }
                else
                {
                    nextCounts[col] += currentCount;
                }
            }

            counts = nextCounts;

            Console.WriteLine($"Processed {row + 1} of {rows} => active columns: {counts.Count(c => c > 0)}");
        }
        
        long total = 0;
        for (int col = 0; col < cols; col++)
        {
            total += counts[col];
        }

        return total;
    }
}