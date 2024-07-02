using System;
using System.Collections.Generic;

class Program
{
    static List<int> GenerateRandomValues(int quantity, int min, int max, int totalBudget)
    {
        List<int> results = new List<int>();
        Random random = new Random();

        for (int i = 0; i < quantity - 1; i++)
        {
            int remainingValues = quantity - i;
            int maxPossibleValue = Math.Min(max, totalBudget - (min * remainingValues));

            int randomValue = random.Next(min, maxPossibleValue + 1);
            results.Add(randomValue);
            totalBudget -= randomValue;
        }

        // The last value is the remaining budget
        results.Add(totalBudget);

        // Ensure that the last value is within the specified min and max range
        results[quantity - 1] = Math.Max(min, Math.Min(max, results[quantity - 1]));

        return results;
    }

    static void Main()
    {
        int quantity = 10; //actual data
        int max = 10;//actual data
        int min = 1;//actual data
        int totalBudget = 50;//actual data
        int minValue = quantity * min;
        int minRequiredBudget = (int)(0.5 * minValue);

        if (totalBudget < minRequiredBudget)
        {
            Console.WriteLine($"Total budget should be at least 50% of minValue ({minRequiredBudget}).");
        }
        else
        {
            List<int> randomValues = GenerateRandomValues(quantity, min, max, totalBudget);

            Console.WriteLine(string.Join(", ", randomValues));
            Console.WriteLine("Total Budget: " + totalBudget);
            Console.WriteLine("Min Required Budget: " + minRequiredBudget);
        }
    }
}
