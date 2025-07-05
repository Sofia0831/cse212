// Added file to test if it works outside of debug


double[] multiples = Arrays.MultiplesOf(7, 5);
Console.WriteLine("Multiples: " + string.Join(", ", multiples));

double[] multiples2 = Arrays.MultiplesOf(-2, 5);
Console.WriteLine("Multiples: " + string.Join(", ", multiples2));

List<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
Arrays.RotateListRight(numbers, 3);
Console.WriteLine("Rotated List: " + string.Join(", ", numbers));