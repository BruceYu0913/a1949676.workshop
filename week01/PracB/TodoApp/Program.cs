class Program
{
    static void Main(string[] args)
    {
        List<string> tasks = new List<string>();

        Console.WriteLine("Welcome to the To-Do Manager!");
        Console.WriteLine();
        Console.WriteLine("Available commands:");
        Console.WriteLine("add    - Add a new task");
        Console.WriteLine("show   - Show all tasks");
        Console.WriteLine("remove - Remove a task by number");
        Console.WriteLine("clear  - Remove all tasks");
        Console.WriteLine("exit   - Close the application");

        while (true)
        {
            Console.Write("\nEnter command: ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Please enter a valid command.");
                continue;
            }

            input = input.Trim().ToLower();

            switch (input)
            {
                case "add":
                    Console.Write("Enter task description: ");
                    string? task = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(task))
                    {
                        Console.WriteLine("Task cannot be empty.");
                    }
                    else
                    {
                        tasks.Add(task.Trim());
                        Console.WriteLine("Task added successfully.");
                    }

                    break;

                case "show":
                    if (tasks.Count == 0)
                    {
                        Console.WriteLine("The to-do list is empty.");
                    }
                    else
                    {
                        Console.WriteLine("\nYour tasks:");

                        for (int index = 0; index < tasks.Count; index++)
                        {
                            Console.WriteLine(
                                $"{index + 1}. {tasks[index]}"
                            );
                        }
                    }

                    break;

                case "remove":
                    if (tasks.Count == 0)
                    {
                        Console.WriteLine(
                            "There are no tasks to remove."
                        );
                        break;
                    }

                    Console.WriteLine("\nYour tasks:");

                    for (int index = 0; index < tasks.Count; index++)
                    {
                        Console.WriteLine(
                            $"{index + 1}. {tasks[index]}"
                        );
                    }

                    Console.Write("Enter task number to remove: ");
                    string? numberInput = Console.ReadLine();

                    if (!int.TryParse(numberInput, out int taskNumber))
                    {
                        Console.WriteLine(
                            "Please enter a valid whole number."
                        );
                    }
                    else if (
                        taskNumber < 1 ||
                        taskNumber > tasks.Count
                    )
                    {
                        Console.WriteLine(
                            "Task number is out of range."
                        );
                    }
                    else
                    {
                        string removedTask = tasks[taskNumber - 1];
                        tasks.RemoveAt(taskNumber - 1);

                        Console.WriteLine(
                            $"Removed task: {removedTask}"
                        );
                    }

                    break;

                case "clear":
                    if (tasks.Count == 0)
                    {
                        Console.WriteLine(
                            "The to-do list is already empty."
                        );
                    }
                    else
                    {
                        tasks.Clear();
                        Console.WriteLine(
                            "All tasks cleared successfully."
                        );
                    }

                    break;

                case "exit":
                    Console.WriteLine(
                        "Exiting TodoApp."
                    );

                    return;

                default:
                    Console.WriteLine(
                        "Unknown command. Please try again."
                    );

                    break;
            }
        }
    }
}