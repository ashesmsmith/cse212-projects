public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // TODO Start Problem 1
        if (n <= 0)
        {
            return 0; // Stops recursion
        }
        else
        {
            // (n*n) + ((n-1)*(n-1)) + ... until 0
            return n * n + SumSquaresRecursive(n - 1);

            // Ex: SumSquaresRecursive(5)
            // (5^2) + (4^2) + (3^2) + (2^2) + (1^2) + 0 = 55
            // (5*5) + ((5-1)*(5-1)) + ((4-1)*(4-1)) + ... 0            
        }
    }


    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations
    /// using the formula: len(letters)! / (len(letters) - size)!
    ///
    /// For example, if letters was [A,B,C] and size was 2 then
    /// the following would the contents of the results array after the function ran: AB, AC, BA, BC, CA, CB (might be in 
    /// a different order).
    ///
    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // TODO Start Problem 2
        // If the word is the required size, add it to the list
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Build permutations
        for (int i = 0; i < letters.Length; i++) // Continue for the length of the string
        {
            // Exclude the letter at index i from future recursion
            // newWord = letters before [i] + letters after [i]
            string newWord = letters.Substring(0, i) + letters.Substring(i + 1);

            // Add the letter at [i] to the end of the word
            PermutationsChoose(results, newWord, size, word + letters[i]);
        }
    }


    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    ///
    /// With just one step to go, the ways to get
    /// to the top of 's' stairs is to either:
    ///
    /// - take a single step from the second to last step, 
    /// - take a double step from the third to last step, 
    /// - take a triple step from the fourth to last step
    ///
    /// We don't need to think about scenarios like taking two 
    /// single steps from the third to last step because this
    /// is already part of the first scenario (taking a single
    /// step from the second to last step).
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.  The parameter
    /// 'remember' has already been added as an input parameter to 
    /// the function for you to complete this task.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Base Cases
        if (s == 0) // 0 steps = 0 ways
            return 0;
        if (s == 1) // 1 step = 1 way
            return 1;
        if (s == 2) // 2 steps = 2 ways
            return 2;
        if (s == 3) // 3 steps = 4 ways
            return 4;

        // TODO Start Problem 3
        // Create the dictionary during first run
        if (remember == null)
        {
            remember = new Dictionary<int, decimal>();
        }

        // Check if previously done and key exists
        if (remember.ContainsKey(s))
        {
            return remember[s];
        }

        // Solve using recursion and add to dictionary
        // Moving 1, 2, or 3 steps at a time
        decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);
        remember[s] = ways; // Add to dictionary

        return ways;
    }


    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    ///	
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // TODO Start Problem 4
        // If empty or there are no wildcards '*', add pattern to list and return
        if (!pattern.Contains('*'))
        {
            results.Add(pattern);
            return;
        }
        else
        {
            var wildIndex = pattern.IndexOf('*', 0); // Index of wildcard

            var prefix = pattern.Substring(0, wildIndex); // Pattern before wildcard
            var suffix = pattern.Substring(wildIndex + 1); // Pattern after wildcard
            WildcardBinary($"{prefix}1{suffix}", results); // Replace wildcard with '1'
            WildcardBinary($"{prefix}0{suffix}", results); // Replace wildcard with '0'
        }
    }


    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // If this is the first time running the function, then we need
        // to initialize the currPath list.
        if (currPath == null)
        {
            currPath = new List<ValueTuple<int, int>>();
        }

        // TODO Start Problem 5
        // Add current location to currPath list
        // Starts with (0, 0)
        currPath.Add((x, y));

        // Check if we are at the end - (2, 2)
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString()); // Convert currPath to a string and add to results
            return;
        }

        // Check for valid moves from current location
        // Move Right
        if (maze.IsValidMove(currPath, x + 1, y))
        {
            SolveMaze(results, maze, x + 1, y, currPath.ToList());
        }

        // Move Left
        if (maze.IsValidMove(currPath, x - 1, y))
        {
            SolveMaze(results, maze, x - 1, y, currPath.ToList());
        }

        // Move Down
        if (maze.IsValidMove(currPath, x, y + 1))
        {
            SolveMaze(results, maze, x, y + 1, currPath.ToList());
        }

        // Move Up
        if (maze.IsValidMove(currPath, x, y - 1))
        {
            SolveMaze(results, maze, x, y - 1, currPath.ToList());
        }

        // Remove location from currPath if invalid
        currPath.RemoveAt(currPath.Count - 1);
    }
}