public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 }; // New list created with values
        var l2 = new[] { 2, 4, 6, 8, 10 }; // New list created with values
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1 }; // New list created with values
        var intResult = ListSelector(l1, l2, select); // call ListSelector function with parameters of above lists
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        var result = new int[select.Length];
        var l1Idx = 0; // Used to track index of first list
        var l2Idx = 0; // Used to track index of second list

        for (var i = 0; i < select.Length; i++)
        {
            if (select[i] == 1)
                result[i] = list1[l1Idx++]; // Add 1 to l1Idx
            else
                result[i] = list2[l2Idx++]; // Add 1 to l2Idx
        }

        return result;
    }
}
