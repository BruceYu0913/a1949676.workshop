using Xunit;

public class UnitTest1
{
    [Fact]
    public void Constructor_CreatesAccountWithExpectedValues()
    {
        var account = new BankAccount("Casey", 500.00m);

        Assert.Equal("Casey", account.Owner);
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
            new BankAccount("Casey", -1.00m)
        );
    }

    [Fact]
    public void DecimalDeposit_IncreasesBalance()
    {
        var account = new BankAccount("Casey", 500.00m);

        account.Deposit(25.50m);

        Assert.Equal(525.50m, account.Balance);
    }

    [Fact]
    public void ZeroDecimalDeposit_DoesNotChangeBalance()
    {
        var account = new BankAccount("Casey", 500.00m);

        account.Deposit(0.00m);

        Assert.Equal(500.00m, account.Balance);
    }

    [Fact]
    public void NegativeDecimalDeposit_Throws()
    {
        var account = new BankAccount("Casey", 500.00m);

        Assert.Throws<ArgumentException>(() =>
            account.Deposit(-1.00m)
        );
    }

    [Fact]
    public void IntDeposit_IncreasesBalance()
    {
        var account = new BankAccount("Casey", 500.00m);

        account.Deposit(25);

        Assert.Equal(525.00m, account.Balance);
    }

    [Fact]
    public void ZeroIntDeposit_DoesNotChangeBalance()
    {
        var account = new BankAccount("Casey", 500.00m);

        account.Deposit(0);

        Assert.Equal(500.00m, account.Balance);
    }

    [Fact]
    public void NegativeIntDeposit_Throws()
    {
        var account = new BankAccount("Casey", 500.00m);

        Assert.Throws<ArgumentException>(() =>
            account.Deposit(-1)
        );
    }

    [Fact]
    public void DoubleDeposit_IncreasesBalance()
    {
        var account = new BankAccount("Casey", 500.00m);

        account.Deposit(25.50);

        Assert.Equal(525.50m, account.Balance);
    }

    [Fact]
    public void ZeroDoubleDeposit_DoesNotChangeBalance()
    {
        var account = new BankAccount("Casey", 500.00m);

        account.Deposit(0.00);

        Assert.Equal(500.00m, account.Balance);
    }

    [Fact]
    public void NegativeDoubleDeposit_Throws()
    {
        var account = new BankAccount("Casey", 500.00m);

        Assert.Throws<ArgumentException>(() =>
            account.Deposit(-1.00)
        );
    }

    [Fact]
    public void Withdraw_DecreasesBalance()
    {
        var account = new BankAccount("Casey", 500.00m);

        account.Withdraw(100.00m);

        Assert.Equal(400.00m, account.Balance);
    }

    [Fact]
    public void ZeroWithdrawal_DoesNotChangeBalance()
    {
        var account = new BankAccount("Casey", 500.00m);

        account.Withdraw(0.00m);

        Assert.Equal(500.00m, account.Balance);
    }

    [Fact]
    public void NegativeWithdrawal_Throws()
    {
        var account = new BankAccount("Casey", 500.00m);

        Assert.Throws<ArgumentException>(() =>
            account.Withdraw(-1.00m)
        );
    }

    [Fact]
    public void InsufficientBalance_Throws()
    {
        var account = new BankAccount("Casey", 500.00m);

        Assert.Throws<InvalidOperationException>(() =>
            account.Withdraw(600.00m)
        );
    }
}