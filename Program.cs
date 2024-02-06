using System;

public class HedgehogColorChange
{
    public static int MinEncountersToChangeColor(int[] population, int desiredColor)
    {
        // Validate input
        if (population == null || population.Length != 3 || desiredColor < 0 || desiredColor > 2)
        {
            throw new ArgumentException("Invalid input.");
        }

        // Check if all hedgehogs are already of the desired color or if desired color is not present initially
        if (population[desiredColor] == population[0] + population[1] + population[2] || population[desiredColor] == 0)
        {
            return -1;
        }

        // Check for the impossibility condition
        if (population[0] % 2 == population[1] % 2 && population[1] % 2 == population[2] % 2)
        {
            return -1;
        }

        // Calculate the minimum number of encounters
        return CalculateMinimumEncounters(population, desiredColor);
    }

    private static int CalculateMinimumEncounters(int[] population, int desiredColor)
    {
        int totalHedgehogs = population[0] + population[1] + population[2];
        return (totalHedgehogs - population[desiredColor]) / 2;
    }

    public static void Main(string[] args)
    {
        try
        {
            // Example input
            int[] population = {4, 1, 4}; // 8 red, 1 green, 9 blue
            int desiredColor = 2; // Target color: blue

            // Calculate the result
            int result = MinEncountersToChangeColor(population, desiredColor);
            if (result == -1) {
                Console.WriteLine($"Error: {result}");
            } else {
                Console.WriteLine($"Minimum encounters needed: {result}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
