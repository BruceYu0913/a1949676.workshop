using System.IO;
using Xunit;

public class UnitTest1
{
    // BankAccount tests

    [Fact]
    public void Constructor_CreatesAccountWithExpectedValues()
    {
        var account = new BankAccount(
            "Bruce",
            500.00m
        );

        Assert.Equal("Bruce", account.Owner);
        Assert.Equal(500.00m, account.Balance);
    }

    [Fact]
    public void EmptyOwner_Throws()
    {
        Assert.Throws<ArgumentException>(() =>
            new BankAccount("", 500.00m)
        );
    }

    [Fact]
    public void NegativeStartingBalance_Throws()
    {
        Assert.Throws<ArgumentException>(() =>
            new BankAccount("Bruce", -1.00m)
        );
    }

    [Fact]
    public void DecimalDeposit_IncreasesBalance()
    {
        var account = new BankAccount(
            "Bruce",
            500.00m
        );

        account.Deposit(25.50m);

        Assert.Equal(525.50m, account.Balance);
    }

    [Fact]
    public void ZeroDecimalDeposit_DoesNotChangeBalance()
    {
        var account = new BankAccount(
            "Bruce",
            500.00m
        );

        account.Deposit(0.00m);

        Assert.Equal(500.00m, account.Balance);
    }

    [Fact]
    public void NegativeDecimalDeposit_Throws()
    {
        var account = new BankAccount(
            "Bruce",
            500.00m
        );

        Assert.Throws<ArgumentException>(() =>
            account.Deposit(-1.00m)
        );
    }

    [Fact]
    public void IntDeposit_IncreasesBalance()
    {
        var account = new BankAccount(
            "Bruce",
            500.00m
        );

        account.Deposit(25);

        Assert.Equal(525.00m, account.Balance);
    }

    [Fact]
    public void DoubleDeposit_IncreasesBalance()
    {
        var account = new BankAccount(
            "Bruce",
            500.00m
        );

        account.Deposit(25.50);

        Assert.Equal(525.50m, account.Balance);
    }

    [Fact]
    public void Withdraw_DecreasesBalance()
    {
        var account = new BankAccount(
            "Bruce",
            500.00m
        );

        account.Withdraw(100.00m);

        Assert.Equal(400.00m, account.Balance);
    }

    [Fact]
    public void ZeroWithdrawal_DoesNotChangeBalance()
    {
        var account = new BankAccount(
            "Bruce",
            500.00m
        );

        account.Withdraw(0.00m);

        Assert.Equal(500.00m, account.Balance);
    }

    [Fact]
    public void NegativeWithdrawal_Throws()
    {
        var account = new BankAccount(
            "Bruce",
            500.00m
        );

        Assert.Throws<ArgumentException>(() =>
            account.Withdraw(-1.00m)
        );
    }

    [Fact]
    public void InsufficientBalance_Throws()
    {
        var account = new BankAccount(
            "Bruce",
            500.00m
        );

        Assert.Throws<InvalidOperationException>(() =>
            account.Withdraw(600.00m)
        );
    }

    [Fact]
    public void DisplayAccountInfo_DisplaysBaseAccountDetails()
    {
        var account = new BankAccount(
            "Bruce",
            500.00m
        );

        var originalOutput = Console.Out;
        var output = new StringWriter();

        Console.SetOut(output);
        account.DisplayAccountInfo();
        Console.SetOut(originalOutput);

        Assert.Contains(
            "Account: BankAccount",
            output.ToString()
        );

        Assert.Contains(
            "Owner: Bruce",
            output.ToString()
        );

        Assert.Contains(
            "Balance: $500.00",
            output.ToString()
        );
    }

    // SavingsAccount tests

    [Fact]
    public void SavingsConstructor_CreatesAccountWithExpectedValues()
    {
        var account = new SavingsAccount(
            "Bruce",
            1000.00m,
            0.05m
        );

        Assert.Equal("Bruce", account.Owner);
        Assert.Equal(1000.00m, account.Balance);
        Assert.Equal(0.05m, account.InterestRate);
    }

    [Fact]
    public void NegativeInterestRate_Throws()
    {
        Assert.Throws<ArgumentException>(() =>
            new SavingsAccount(
                "Bruce",
                1000.00m,
                -0.05m
            )
        );
    }

    [Fact]
    public void ApplyInterest_IncreasesBalance()
    {
        var account = new SavingsAccount(
            "Bruce",
            1000.00m,
            0.05m
        );

        account.ApplyInterest();

        Assert.Equal(1050.00m, account.Balance);
    }

    [Fact]
    public void ZeroInterestRate_DoesNotChangeBalance()
    {
        var account = new SavingsAccount(
            "Bruce",
            1000.00m,
            0.00m
        );

        account.ApplyInterest();

        Assert.Equal(1000.00m, account.Balance);
    }

    [Fact]
    public void SavingsDisplayAccountInfo_DisplaysSavingsDetails()
    {
        var account = new SavingsAccount(
            "Bruce",
            1500.00m,
            0.035m
        );

        var originalOutput = Console.Out;
        var output = new StringWriter();

        Console.SetOut(output);
        account.DisplayAccountInfo();
        Console.SetOut(originalOutput);

        Assert.Contains(
            "Account: SavingsAccount",
            output.ToString()
        );

        Assert.Contains(
            "Owner: Bruce",
            output.ToString()
        );

        Assert.Contains(
            "Balance: $1500.00",
            output.ToString()
        );

        Assert.Contains(
            "Interest rate: 3.5%",
            output.ToString()
        );
    }

    // CheckingAccount tests

    [Fact]
    public void CheckingConstructor_CreatesAccountWithExpectedValues()
    {
        var account = new CheckingAccount(
            "Yu",
            500.00m,
            2.00m
        );

        Assert.Equal("Yu", account.Owner);
        Assert.Equal(500.00m, account.Balance);
        Assert.Equal(2.00m, account.TransactionFee);
    }

    [Fact]
    public void NegativeTransactionFee_Throws()
    {
        Assert.Throws<ArgumentException>(() =>
            new CheckingAccount(
                "Yu",
                500.00m,
                -2.00m
            )
        );
    }

    [Fact]
    public void CheckingWithdraw_DeductsAmountAndFee()
    {
        var account = new CheckingAccount(
            "Yu",
            500.00m,
            2.00m
        );

        account.Withdraw(100.00m);

        Assert.Equal(398.00m, account.Balance);
    }

    [Fact]
    public void CheckingNegativeWithdrawal_Throws()
    {
        var account = new CheckingAccount(
            "Yu",
            500.00m,
            2.00m
        );

        Assert.Throws<ArgumentException>(() =>
            account.Withdraw(-1.00m)
        );
    }

    [Fact]
    public void CheckingInsufficientBalance_Throws()
    {
        var account = new CheckingAccount(
            "Yu",
            100.00m,
            2.00m
        );

        Assert.Throws<InvalidOperationException>(() =>
            account.Withdraw(99.00m)
        );
    }

    [Fact]
    public void CheckingDisplayAccountInfo_DisplaysCheckingDetails()
    {
        var account = new CheckingAccount(
            "Yu",
            500.00m,
            2.00m
        );

        var originalOutput = Console.Out;
        var output = new StringWriter();

        Console.SetOut(output);
        account.DisplayAccountInfo();
        Console.SetOut(originalOutput);

        Assert.Contains(
            "Account: CheckingAccount",
            output.ToString()
        );

        Assert.Contains(
            "Owner: Yu",
            output.ToString()
        );

        Assert.Contains(
            "Balance: $500.00",
            output.ToString()
        );

        Assert.Contains(
            "Transaction fee: $2.00",
            output.ToString()
        );
    }
}