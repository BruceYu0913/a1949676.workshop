class Program
{
    private static void Main()
    {
        List<string> students = [];

        students.Add("Bruce");
        students.Add("Tony");

        students.Insert(1, "Josh");

        students.Remove("Bruce");
        students.Remove("Tony");
        students.Remove("Josh");

        string[] taskNames =
        {
            "Bruce",
            "Tony",
            "Josh",
            "Ayo",
            "Ash",
            "Ella",
            "Joshua",
            "Ben",
            "Joanah",
            "Christine"
        };

        List<string> convertedNames =
            new List<string>(taskNames);

        students.AddRange(convertedNames);

        Console.WriteLine("All student names:");
        PrintList(students);

        Console.WriteLine();
        Console.WriteLine(
            $"Total students: {students.Count}"
        );

        string searchedName = "Bruce";

        int nameIndex = FindNameIndex(
            students,
            searchedName
        );

        Console.WriteLine();

        if (nameIndex >= 0)
        {
            Console.WriteLine(
                $"{searchedName} was found at " +
                $"index {nameIndex}."
            );
        }
        else
        {
            Console.WriteLine(
                $"{searchedName} was not found."
            );
        }

        string partialName = "Jo";

        List<string> matchingNames =
            FindPartialMatches(
                students,
                partialName
            );

        Console.WriteLine();
        Console.WriteLine(
            $"Names containing \"{partialName}\":"
        );

        PrintList(matchingNames);

        int totalLength =
            SumNameLengths(students);

        Console.WriteLine();
        Console.WriteLine(
            $"Total length of all names: " +
            $"{totalLength}"
        );

        string[] convertedBackToArray =
            students.ToArray();

        Console.WriteLine();
        Console.WriteLine(
            "List converted back to an array:"
        );

        PrintArray(convertedBackToArray);
    }

    private static int FindNameIndex(
        List<string> names,
        string searchedName
    )
    {
        return names.IndexOf(searchedName);
    }

    private static List<string> FindPartialMatches(
        List<string> names,
        string partialName
    )
    {
        List<string> matches = [];

        foreach (string name in names)
        {
            if (name.Contains(partialName))
            {
                matches.Add(name);
            }
        }

        return matches;
    }

    private static int SumNameLengths(
        List<string> names
    )
    {
        int totalLength = 0;

        foreach (string name in names)
        {
            totalLength += name.Length;
        }

        return totalLength;
    }

    private static void PrintList(
        List<string> names
    )
    {
        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
    }

    private static void PrintArray(
        string[] names
    )
    {
        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
    }
}