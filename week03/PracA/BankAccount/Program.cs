class Program
{
    private static void Main()
    {
        try
        {
            SavingsAccount savings = new SavingsAccount(
                "Bruce",
                1500.00m,
                0.035m
            );

            CheckingAccount checking = new CheckingAccount(
                "Yu",
                1000.00m,
                2.00m
            );

            savings.DisplayAccountInfo();

            Console.WriteLine();

            checking.DisplayAccountInfo();
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