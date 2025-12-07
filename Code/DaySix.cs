using System.Data;
using System.Text.RegularExpressions;

namespace Code;

public class DaySix
{
    public Int64 PartOne(string input)
    {
        var operations = new Dictionary<string, Func<Int64, int, Int64>>
        {
            { "+", (acc, num) => acc + num },
            { "*", (acc, num) => acc * num }
        };
        
        Int64 result = 0;

        var (numbers, operators) = ParseMatrix(input);

        for (int i = 0; i < numbers.GetLength(1); i++)
        {
            Int64 tempResult = numbers[0, i];
            
            for (int j = 1; j < numbers.GetLength(0); j++)
            {
                tempResult = operations[operators[i]](tempResult, numbers[j, i]);
            }
            
            result += tempResult;
        }

        return result;
    }
    
    private (int[,] numbers, string[] operators) ParseMatrix(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        
        var numberLines = lines.Take(lines.Length - 1).ToArray();
        var operatorLine = lines.Last();
        
        // Parse operators
        var operators = operatorLine.Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(op => !string.IsNullOrEmpty(op)).ToArray();
        
        int rows = numberLines.Length;
        int cols = numberLines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
        int[,] numbers = new int[rows, cols];
    
        for (int i = 0; i < rows; i++)
        {
            var values = numberLines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < cols; j++)
            {
                numbers[i, j] = int.Parse(values[j]);
            }
        }
    
        return (numbers, operators);
    }
    
    public Int64 PartTwo(string input, int cellLength = 3)
    {
        var operations = new Dictionary<string, Func<Int64, int, Int64>>
        {
            { "+", (acc, num) => acc + num },
            { "*", (acc, num) => acc * num }
        };
        
        Int64 result = 0;
        
        var (tempNumbers, operators) = ParseStringMatrix(input, cellLength);

        int[,] numbers = ParseRTL(tempNumbers, operators);

        for (int i = 0; i < numbers.GetLength(1); i++)
        {
            Int64 tempResult = numbers[0, i];
            
            for (int j = 1; j < numbers.GetLength(0); j++)
            {
                tempResult = operations[operators[i]](tempResult, numbers[j, i]);
            }
            
            result += tempResult;
        }

        return result;
    }
    
    private (string[,] numbers, string[] operators) ParseStringMatrix(string input, int cellLength)
    {
        var (n, o) = ParseMatrix(input);
        
        int[] maxDigitsArray = new int[n.GetLength(1)];

        for (int col = 0; col < n.GetLength(1); col++)
        {
            int max = n[0, col].ToString().Length;
            
            for (int row = 1; row < n.GetLength(0); row++)
            {
                if (max < n[row, col].ToString().Length)
                {
                    max = n[row, col].ToString().Length;
                }
            }
            
            maxDigitsArray[col] = max;
        }
        
        var lines = input.Split('\n');

        var numberLines = lines.Take(lines.Length - 1).ToArray();
        var operatorLine = lines.Last();
        
        // Parse operators
        var operators = operatorLine.Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(op => !string.IsNullOrEmpty(op)).ToArray();

        int rows = numberLines.Length;
        int cols = maxDigitsArray.Length;
        
        string[,] numberStrings = new string[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            int col = 0;
            string numberLine = numberLines[i].Replace(" ", "0");
            int index = 0;
            for (int c = 0; c < maxDigitsArray.Length; c++)
            {
                numberStrings[i, c] = numberLine.Substring(index, maxDigitsArray[c]).PadLeft(cellLength, '0');
                index += maxDigitsArray[c] + 1;
            }
        }

        return (numberStrings, operators);
    }

    private int[,] ParseRTL(string[,] numbers, string[] operators)
    {
        int numCols = numbers.GetLength(1);
        int numRows = numbers.GetLength(0);

        // Find max digits across all numbers
        int maxDigits = 0;
        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numCols; col++)
            {
                maxDigits = Math.Max(maxDigits, numbers[row, col].Length);
            }
        }
        
        string[,] finalStringNumbers = new string[maxDigits, numCols];
        
        for (int col = 0; col < numCols; col++)
        {
            for (int pos = 0; pos < maxDigits; pos++)
            {
                for (int row = 0; row < numRows; row++)
                {
                    finalStringNumbers[pos, col] += numbers[row, col][pos];
                }
            }
        }
        
        int[,] finalNumbers = new int[maxDigits, numCols];
        
        for (int row = 0; row < maxDigits; row++)
        {
            for (int col = 0; col < numCols; col++)
            {
                string number = finalStringNumbers[row, col].Replace("0", "").Trim();
                if (string.IsNullOrEmpty(number))
                {
                    finalNumbers[row, col] = operators[col] == "*" ? 1 : 0;
                }
                else
                {
                    finalNumbers[row, col] = int.Parse(finalStringNumbers[row, col].Replace("0", "").Trim());
                }
            }
        }

        return finalNumbers;
    }
}