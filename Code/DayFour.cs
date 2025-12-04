namespace Code;

public class DayFour
{
    public int PartOne(string input)
    {
        int count = 0;
    
        char[][] matrix = input
            .Split('\n')
            .Select(line => line.Trim()) 
            .Where(line => !string.IsNullOrEmpty(line)) 
            .Select(line => line.ToCharArray())
            .ToArray();

        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] != '@')
                {
                    continue;
                }

                int neighbors = 0;
                for (int x = -1; x <= 1; x++)
                {
                    for (int y = -1; y <= 1; y++)
                    {
                        if (x == 0 && y == 0)
                        {
                            continue;
                        }

                        int xToCheck = i + x;
                        int yToCheck = j + y;
                        
                        if (xToCheck < 0 || yToCheck < 0 || 
                            xToCheck >= matrix.Length || 
                            yToCheck >= matrix[0].Length)
                        {
                            continue;
                        }

                        if (matrix[xToCheck][yToCheck] == '@')
                        {
                            neighbors++;
                        }
                    }
                }

                if (neighbors < 4)
                {
                    count++;
                }
            }
        }

        return count;
    }
}