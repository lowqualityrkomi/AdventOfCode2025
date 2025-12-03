namespace Code;

public class DayThree
{
    public Int128 PartOne(string banks, int digitsToGet)
    {
        Int128 result = 0;

        List<string> banksArray = banks.Split('\n').ToList();
    
        banksArray.ForEach(bank =>
        {
            Int128 sum = 0;
            int numbersToExclude = digitsToGet - 1;
            int index = 0;
        
            for (int i = 0; i < digitsToGet; i++)
            {
                Int128 bigger = 0;
                int skip = i == 0 ? 0 : 1;
                
                for (int j = index + skip; j < bank.Length - numbersToExclude; j++)
                {
                    int current = Int32.Parse(bank[j].ToString());
                    if (current > bigger)
                    {
                        bigger = current;
                        index = j;
                    }
                }

                bigger *= (Int128)Math.Pow(10, numbersToExclude);

                sum += bigger;
            
                numbersToExclude--;
            }

            result += sum;
        });
    
        return result;
    }
}