class Program
{
    private static void Main()
    {
        string[] names =
        {
            "Bruce","Tony","Josh","Ayo"
        };

        Console.WriteLine("All names:");
        PrintArray(names);

        string longestName = names[0];
        string shortestName = names[0];

        foreach (string name in names)
        {
            if (name.Length > longestName.Length)
            {
                longestName = name;
            }

            if (name.Length < shortestName.Length)
            {
                shortestName = name;
            }
        }

        Console.WriteLine();
        Console.WriteLine(
            $"Longest name: {longestName}"
        );

        Console.WriteLine(
            $"Shortest name: {shortestName}"
        );

        Console.WriteLine();
        Console.WriteLine("Before sorting:");
        PrintArray(names);

        Array.Sort(names);

        Console.WriteLine();
        Console.WriteLine("After sorting:");
        PrintArray(names);

        Console.WriteLine();
        Console.WriteLine("Before reversing:");
        PrintArray(names);

        Array.Reverse(names);

        Console.WriteLine();
        Console.WriteLine("After reversing:");
        PrintArray(names);
    }

    private static void PrintArray(string[] names)
    {
        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
    }
}