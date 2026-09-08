class Program
{
    private static void Main()
    {
        Stack<BankAccount> accountStack =
            new Stack<BankAccount>();

        accountStack.Push(
            new BankAccount("Account01", 1000.00m)
        );

        accountStack.Push(
            new BankAccount("Account02", 1200.00m)
        );

        accountStack.Push(
            new BankAccount("Account03", 1400.00m)
        );

        accountStack.Push(
            new BankAccount("Account04", 1600.00m)
        );

        accountStack.Push(
            new BankAccount("Account05", 1800.00m)
        );

        accountStack.Push(
            new BankAccount("Account06", 2000.00m)
        );

        accountStack.Push(
            new BankAccount("Account07", 2200.00m)
        );

        accountStack.Push(
            new BankAccount("Account08", 2400.00m)
        );

        accountStack.Push(
            new BankAccount("Account09", 2600.00m)
        );

        accountStack.Push(
            new BankAccount("Account10", 2800.00m)
        );

        Console.WriteLine("Stack accounts:");
        PrintStack(accountStack);

        Queue<BankAccount> accountQueue =
            StackToQueue(accountStack);

        Console.WriteLine();
        Console.WriteLine("Queue accounts:");
        PrintQueue(accountQueue);
    }

    private static Queue<BankAccount> StackToQueue(
        Stack<BankAccount> accountStack
    )
    {
        Queue<BankAccount> accountQueue =
            new Queue<BankAccount>();

        foreach (BankAccount account in accountStack)
        {
            accountQueue.Enqueue(account);
        }

        return accountQueue;
    }

    private static void PrintStack(
        Stack<BankAccount> accounts
    )
    {
        foreach (BankAccount account in accounts)
        {
            Console.WriteLine(
                $"{account.Owner}: ${account.Balance:F2}"
            );
        }
    }

    private static void PrintQueue(
        Queue<BankAccount> accounts
    )
    {
        foreach (BankAccount account in accounts)
        {
            Console.WriteLine(
                $"{account.Owner}: ${account.Balance:F2}"
            );
        }
    }
}