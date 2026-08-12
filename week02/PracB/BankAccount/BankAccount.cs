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

    public void Deposit(int amount)
    {
        Deposit((decimal)amount);
    }

    public void Deposit(double amount)
    {
        Deposit((decimal)amount);
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