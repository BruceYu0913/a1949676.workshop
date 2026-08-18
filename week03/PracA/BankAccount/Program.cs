class Program
{
    private static void Main()
    {
        try
        {
            SavingsAccount savings = new SavingsAccount(
                "Bruce",
                1000.00m,
                0.05m
            );

            Console.WriteLine("Savings account");
            Console.WriteLine($"Owner: {savings.Owner}");
            Console.WriteLine(
                $"Starting balance: ${savings.Balance:F2}"
            );

            savings.ApplyInterest();

            Console.WriteLine(
                $"Balance after interest: ${savings.Balance:F2}"
            );

            Console.WriteLine();

            CheckingAccount checking = new CheckingAccount(
                "Yu",
                500.00m,
                2.00m
            );

            Console.WriteLine("Checking account");
            Console.WriteLine($"Owner: {checking.Owner}");
            Console.WriteLine(
                $"Starting balance: ${checking.Balance:F2}"
            );

            checking.Withdraw(100.00m);

            Console.WriteLine(
                $"Balance after $100 withdrawal: " +
                $"${checking.Balance:F2}"
            );

            Console.WriteLine(
                $"Transaction fee: ${checking.TransactionFee:F2}"
            );
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine(
                $"Error: {exception.Message}"
            );
        }
        catch (InvalidOperationException exception)
        {
            Console.WriteLine(
                $"Error: {exception.Message}"
            );
        }
    }
}