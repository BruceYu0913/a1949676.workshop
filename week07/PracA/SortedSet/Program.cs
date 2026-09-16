class Program
{
    private static void Main()
    {
        SortedSet<BankAccount> accountsSet =
            new SortedSet<BankAccount>(
                new BankComparer()
            );

        accountsSet.Add(
            new BankAccount("Bruce", 35m)
        );

        accountsSet.Add(
            new BankAccount("Tony", 10m)
        );

        accountsSet.Add(
            new BankAccount("Josh", 45m)
        );

        accountsSet.Add(
            new BankAccount("Ayo", 20m)
        );

        accountsSet.Add(
            new BankAccount("Ash", 30m)
        );

        accountsSet.Add(
            new BankAccount("Ella", 15m)
        );

        accountsSet.Add(
            new BankAccount("Joshua", 50m)
        );

        accountsSet.Add(
            new BankAccount("Ben", 25m)
        );

        accountsSet.Add(
            new BankAccount("Joanah", 40m)
        );

        accountsSet.Add(
            new BankAccount("Christine", 30m)
        );

        Console.WriteLine("Initial accounts:");
        DisplayAccounts(accountsSet);

        accountsSet.Add(
            new BankAccount("Yu", 60m)
        );

        Console.WriteLine();
        Console.WriteLine(
            "After adding a new highest balance:"
        );

        DisplayAccounts(accountsSet);

        bool added = accountsSet.Add(
            new BankAccount("Bruce", 35m)
        );

        Console.WriteLine();
        Console.WriteLine(
            "After trying to add a duplicate account:"
        );

        Console.WriteLine($"Was it added? {added}");
        DisplayAccounts(accountsSet);

        CreateAccountChart(accountsSet);
    }

    private static void DisplayAccounts(
        SortedSet<BankAccount> accounts
    )
    {
        foreach (BankAccount account in accounts)
        {
            Console.WriteLine(
                $"{account.Owner}: ${account.Balance:F2}"
            );
        }

        Console.WriteLine(
            $"Total accounts: {accounts.Count}"
        );
    }

    private static void CreateAccountChart(
        SortedSet<BankAccount> accounts
    )
    {
        double[] balances = new double[accounts.Count];

        int index = 0;

        foreach (BankAccount account in accounts)
        {
            balances[index] = (double)account.Balance;
            index++;
        }

        ScottPlot.Plot myPlot =
            new ScottPlot.Plot();

        myPlot.Add.Bars(balances);

        myPlot.YLabel("Account Balance");
        myPlot.XLabel("Ranking");

        myPlot.Axes.Left.Label.FontSize = 20;
        myPlot.Axes.Bottom.Label.FontSize = 20;

        myPlot.Axes.Margins(
            bottom: 0,
            top: 0.2
        );

        myPlot.SavePng(
            "Topic7A-Task3.png",
            800,
            600
        );

        Console.WriteLine();
        Console.WriteLine(
            "Created Topic7A-Task3.png"
        );
    }
}