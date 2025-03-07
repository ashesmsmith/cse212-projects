using System.ComponentModel.DataAnnotations;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // * PLAN
        // Multiple the 'number' by another number, starting with 1 and increasing by 1 up to 'length' times
        // 1. Create an array using the 'length' for size to hold the results
        // 2. Loop through 'length' times, multiplying 'number' by each index + 1 (starting from 1 to 'length')
        // 3. Add result to the array in current index position
        // 4. Return the results

        double[] results = new double[length]; // Create array the size of 'length'

        // loop through array 'length' times and fill with multiples of 'number'
        for (int i = 0; i < length; i++)
        {
            results[i] = number * (i + 1); // 'insert multiple at current index
        }

        return results; // return array results
    }


    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // * PLAN
        // Move 'data' to the right by 'amount'
        // 1. Count how many elements are in the 'data' list
        // 2. Get the remainder(%) of 'amount'/length to find the correct amount of rotations needed
        //      -If the remainder is 0 then no rotation is needed
        // 3. Use GetRange to create 2 new lists for 'data' before and after 'amount' remainder index
        // 4. Use Clear to empty the 'data' list
        // 5. Use AddRange to add the new lists into 'data' list in reverse order

        var length = data.Count; // Count how many element are in 'data' list
        amount = amount % length; // Find the remainder/actual rotations

        if (amount == 0)
        {
            return; // No rotation happens and the list stays the same
        }

        // Get values starting at index [0] up to index [length - amount]
        // Store values in a new list
        List<int> part1 = data.GetRange(0, length - amount);

        // Get values starting at index [length - amount] counting up to 'amount' indexes
        // Store values in a new list
        List<int> part2 = data.GetRange(length - amount, amount);

        data.Clear(); // Clear original list
        data.AddRange(part2); // Add the second part of original list to the beginning
        data.AddRange(part1); // Add the first part of the original list to the end
    }
}
