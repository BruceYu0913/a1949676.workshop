class Program
{
    private static void Main()
    {
        Queue<string> printQueue =
            new Queue<string>();

        PrintQueue("Initial queue:", printQueue);

        printQueue.Enqueue("Print Job 1");
        PrintQueue(
            "After Enqueue(\"Print Job 1\"):",
            printQueue
        );

        printQueue.Enqueue("Print Job 2");
        PrintQueue(
            "After Enqueue(\"Print Job 2\"):",
            printQueue
        );

        printQueue.Enqueue("Print Job 3");
        PrintQueue(
            "After Enqueue(\"Print Job 3\"):",
            printQueue
        );

        string nextJob = printQueue.Peek();

        Console.WriteLine();
        Console.WriteLine($"Peek result: {nextJob}");

        PrintQueue(
            "Queue after Peek():",
            printQueue
        );

        string completedJob = printQueue.Dequeue();

        Console.WriteLine();
        Console.WriteLine(
            $"Dequeue result: {completedJob}"
        );

        PrintQueue(
            "Queue after Dequeue():",
            printQueue
        );
    }

    private static void PrintQueue(
        string title,
        Queue<string> printQueue
    )
    {
        Console.WriteLine();
        Console.WriteLine(title);

        if (printQueue.Count == 0)
        {
            Console.WriteLine("(empty)");
        }
        else
        {
            foreach (string job in printQueue)
            {
                Console.WriteLine(job);
            }
        }
    }
}