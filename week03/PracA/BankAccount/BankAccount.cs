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

public class SavingsAccount : BankAccount
{
    public decimal InterestRate { get;set; }

    public SavingsAccount(
        string owner,
        decimal balance,
        decimal interestRate
    ) : base(owner, balance)
    {
        if (interestRate < 0)
        {
            throw new ArgumentException(
                "Interest rate cannot be negative."
            );
        }

        InterestRate = interestRate;
    }

    public void ApplyInterest()
    {
        decimal interest = Balance * InterestRate;
        Deposit(interest);
    }
}

public class CheckingAccount : BankAccount
{
    public decimal TransactionFee { get; set; }

    public CheckingAccount(
        string owner,
        decimal balance,
        decimal transactionFee
    ) : base(owner, balance)
    {
        if (transactionFee < 0)
        {
            throw new ArgumentException(
                "Transaction fee cannot be negative."
            );
        }

        TransactionFee = transactionFee;
    }

    public override void Withdraw(decimal amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException(
                "Withdrawal amount cannot be negative."
            );
        }

        decimal totalAmount = amount + TransactionFee;
        base.Withdraw(totalAmount);
    }
}