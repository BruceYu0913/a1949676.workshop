class Program
{
    private static void Main()
    {
        try
        {
            BankAccount account = new BankAccount("Casey", 500.00m);

            Console.WriteLine($"Owner: {account.Owner}");
            Console.WriteLine($"Starting balance: ${account.Balance:F2}");

            Console.WriteLine("Deposit(decimal): $200.50");
            account.Deposit(200.50m);
            Console.WriteLine($"Balance: ${account.Balance:F2}");

            Console.WriteLine("Deposit(int): $100");
            account.Deposit(100);
            Console.WriteLine($"Balance: ${account.Balance:F2}");

            Console.WriteLine("Deposit(double): $50.25");
            account.Deposit(50.25);
            Console.WriteLine($"Balance: ${account.Balance:F2}");

            account.Withdraw(150.00m);
            Console.WriteLine($"Balance after withdrawal: ${account.Balance:F2}");

            account.Withdraw(1000.00m);
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine($"Error: {exception.Message}");
        }
        catch (InvalidOperationException exception)
        {
            Console.WriteLine($"Error: {exception.Message}");
        }
    }
}
