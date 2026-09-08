class Program
{
    private static void Main()
    {
        Stack<string> undoHistory =
            new Stack<string>();

        PrintStack(
            "Initial stack:",
            undoHistory
        );

        undoHistory.Push("Typed Text");

        PrintStack(
            "After Push(\"Typed Text\"):",
            undoHistory
        );

        undoHistory.Push("Inserted Image");

        PrintStack(
            "After Push(\"Inserted Image\"):",
            undoHistory
        );

        undoHistory.Push("Changed Colour");

        PrintStack(
            "After Push(\"Changed Colour\"):",
            undoHistory
        );

        string topAction = undoHistory.Peek();

        Console.WriteLine();
        Console.WriteLine(
            $"Peek result: {topAction}"
        );

        PrintStack(
            "Stack after Peek():",
            undoHistory
        );

        string removedAction = undoHistory.Pop();

        Console.WriteLine();
        Console.WriteLine(
            $"Pop result: {removedAction}"
        );

        PrintStack(
            "Stack after Pop():",
            undoHistory
        );
    }

    private static void PrintStack(
        string title,
        Stack<string> undoHistory
    )
    {
        Console.WriteLine();
        Console.WriteLine(title);

        if (undoHistory.Count == 0)
        {
            Console.WriteLine("(empty)");
        }
        else
        {
            foreach (string action in undoHistory)
            {
                Console.WriteLine(action);
            }
        }
    }
}