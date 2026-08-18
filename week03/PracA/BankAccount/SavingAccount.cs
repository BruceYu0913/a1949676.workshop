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

    public override void DisplayAccountInfo()
    {
        Console.WriteLine("Account: SavingsAccount");
        Console.WriteLine($"Owner: {Owner}");
        Console.WriteLine($"Balance: ${Balance:F2}");
        Console.WriteLine(
            $"Interest rate: {InterestRate * 100:F1}%"
        );
    }
}