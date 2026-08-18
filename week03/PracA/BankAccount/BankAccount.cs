public class BankAccount
{
    public string Owner { get; set; }
    public decimal Balance { get; set; }

    public BankAccount(string owner, decimal balance)
    {
        if (string.IsNullOrWhiteSpace(owner))
        {
            throw new ArgumentException(
                "Owner cannot be empty."
            );
        }

        if (balance < 0)
        {
            throw new ArgumentException(
                "Starting balance cannot be negative."
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

        Balance = Balance + amount;
    }

    public void Deposit(int amount)
    {
        Deposit((decimal)amount);
    }

    public void Deposit(double amount)
    {
        Deposit((decimal)amount);
    }

    public virtual void Withdraw(decimal amount)
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
                "Balance is too low."
            );
        }

        Balance = Balance - amount;
    }
}
