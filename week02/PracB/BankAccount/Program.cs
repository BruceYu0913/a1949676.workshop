using System;

public class BankAccount
{
    public decimal Balance { get; private set; }
    public string Owner { get; set; }
    
    public BankAccount(string owner, decimal balance)
    {
        if (string.IsNullOrWhiteSpace(owner))
        {
            throw new ArgumentException(
                "Owner name cannot be empty."
            );
        }

        if (balance < 0)
        {
            throw new ArgumentException(
                "Balance cannot be negative."
            );
        }

        Owner = owner;
        Balance = balance;
    }
    public void Deposit(decimal amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException(
                "Deposit amount cannot be negative."
            );
        }

        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException(
                "Withdrawal amount cannot be negative."
            );
        }

        if (amount > Balance)
        {
            throw new InvalidOperationException(
                "Balance too low."
            );
        }

        Balance -= amount;
    }

}

class Program
{
    private static void Main()
    {
        try
        {
            BankAccount account = new BankAccount("Casey", 500.00m);

            Console.WriteLine($"Owner: {account.Owner}");
            Console.WriteLine($"Starting balance: ${account.Balance:F2}");

            account.Deposit(200.00m);
            Console.WriteLine($"Balance after deposit: ${account.Balance:F2}");

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