public static class DisplaySums
{
    public static void Run()
    {
        DisplaySumPairs([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
        // Should show something like (order does not matter):
        // 6 4
        // 7 3
        // 8 2
        // 9 1 

        Console.WriteLine("------------");
        DisplaySumPairs([-20, -15, -10, -5, 0, 5, 10, 15, 20]);
        // Should show something like (order does not matter):
        // 10 0
        // 15 -5
        // 20 -10

        Console.WriteLine("------------");
        DisplaySumPairs([5, 11, 2, -4, 6, 8, -1]);
        // Should show something like (order does not matter):
        // 8 2
        // -1 11
    }

    /// <summary>
    /// Display pairs of numbers (no duplicates should be displayed) that sum to
    /// 10 using a set in O(n) time.  We are assuming that there are no duplicates
    /// in the list.
    /// </summary>
    /// <param name="numbers">array of integers</param>
    private static void DisplaySumPairs(int[] numbers)
    {
        // TODO Problem 2 - This should print pairs of numbers in the given array

        var numbersSet = new HashSet<int>(numbers); // Convert numbers Array to Set
        var sumPairs = new HashSet<int>(); // Create an empty Set for pairs

        foreach (var x in numbers)
        {
            var y = 10 - x;

            // Check that 'x' has not been used/added to sumPairs yet
            // Check that 'y' exists in the numbers array/set
            // Check that 'x' and 'y' are not the same number
            if (!sumPairs.Contains(x) && numbersSet.Contains(y) && x != y)
            {
                sumPairs.Add(x);
                sumPairs.Add(y);

                Console.WriteLine($"{x} {y}");
            }
        }
    }
}