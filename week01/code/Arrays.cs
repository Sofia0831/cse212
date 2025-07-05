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

        // new array to store the multiples, length of array is determined by Length
        var result = new double[length];
        // for loop to iterate length times
        for (var i = 0; i < length; i++)
        {
            //this will calculate in each loop iteration and store the multiples into result
            // for example: for number = 7, 7 * (0 + 1) = 7, 7 * (1 + 1) = 14, 7 * (2 + 1) = 21, and so on
            result[i] = number * (i + 1);
        }

        return result; // replace this return statement with your own
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

        // get the starting index where the list will split according to amount
        // for data = {1, 2, 3, 4, 5, 6, 7, 8, 9} amount = 3
        // startIndex = 9 - 3 = 6 the index will be 6 which contains the number 7
        int startIndex = data.Count - amount;

        // temporary list that will store the numbers to be rotated
        // GetRange will slice the data starting from the startIndex at 6
        // for data = {1, 2, 3, 4, 5, 6, 7, 8, 9} it will be {7, 8, 9}
        List<int> slicedData = data.GetRange(startIndex, amount);

        // remove the numbers to be rotated from the original list
        // this will remove 7 - 9 
        data.RemoveRange(startIndex, amount);

        // add the numbers to be rotated that was stored in a temporary list to the beginning (at index 0) of the original list
        // {7, 8, 9, 1, 2, 3, 4, 5, 6}
        data.InsertRange(0, slicedData);

    }
}
