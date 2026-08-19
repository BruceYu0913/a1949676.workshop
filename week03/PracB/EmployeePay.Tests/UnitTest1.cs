using Xunit;

public class UnitTest1
{
    // FullTimeEmployee tests

    [Fact]
    public void FullTimeConstructor_CreatesExpectedEmployee()
    {
        var employee = new FullTimeEmployee(
            "Bruce",
            75000.00m
        );

        Assert.Equal("Bruce", employee.Name);
        Assert.Equal(75000.00m, employee.AnnualSalary);
    }

    [Fact]
    public void EmptyEmployeeName_Throws()
    {
        Assert.Throws<ArgumentException>(() =>
            new FullTimeEmployee(
                "",
                75000.00m
            )
        );
    }

    [Fact]
    public void NegativeAnnualSalary_Throws()
    {
        Assert.Throws<ArgumentException>(() =>
            new FullTimeEmployee(
                "Bruce",
                -1.00m
            )
        );
    }

    [Fact]
    public void FullTimeCalculatePay_ReturnsPayAfterTax()
    {
        var employee = new FullTimeEmployee(
            "Bruce",
            75000.00m
        );

        decimal pay = employee.CalculatePay();

        Assert.Equal(60000.00m, pay);
    }

    [Fact]
    public void ZeroAnnualSalary_ReturnsZeroPay()
    {
        var employee = new FullTimeEmployee(
            "Bruce",
            0.00m
        );

        decimal pay = employee.CalculatePay();

        Assert.Equal(0.00m, pay);
    }

    [Fact]
    public void FullTimeGenerateReport_ReturnsExpectedDetails()
    {
        IReportable employee = new FullTimeEmployee(
            "Bruce",
            75000.00m
        );

        string report = employee.GenerateReport();

        Assert.Contains(
            "Full-time employee: Bruce",
            report
        );

        Assert.Contains(
            "Annual salary: $75000.00",
            report
        );

        Assert.Contains(
            "Net annual pay: $60000.00",
            report
        );
    }

    // Contractor tests

    [Fact]
    public void ContractorConstructor_CreatesExpectedEmployee()
    {
        var employee = new Contractor(
            "Yu",
            50.00m,
            40.00m
        );

        Assert.Equal("Yu", employee.Name);
        Assert.Equal(50.00m, employee.Rate);
        Assert.Equal(40.00m, employee.Hours);
    }

    [Fact]
    public void NegativeContractorRate_Throws()
    {
        Assert.Throws<ArgumentException>(() =>
            new Contractor(
                "Yu",
                -1.00m,
                40.00m
            )
        );
    }

    [Fact]
    public void NegativeContractorHours_Throws()
    {
        Assert.Throws<ArgumentException>(() =>
            new Contractor(
                "Yu",
                50.00m,
                -1.00m
            )
        );
    }

    [Fact]
    public void ContractorCalculatePay_ReturnsPayAfterTax()
    {
        var employee = new Contractor(
            "Yu",
            50.00m,
            40.00m
        );

        decimal pay = employee.CalculatePay();

        Assert.Equal(1600.00m, pay);
    }

    [Fact]
    public void ZeroContractorHours_ReturnsZeroPay()
    {
        var employee = new Contractor(
            "Yu",
            50.00m,
            0.00m
        );

        decimal pay = employee.CalculatePay();

        Assert.Equal(0.00m, pay);
    }

    [Fact]
    public void ContractorGenerateReport_ReturnsExpectedDetails()
    {
        IReportable employee = new Contractor(
            "Yu",
            50.00m,
            40.00m
        );

        string report = employee.GenerateReport();

        Assert.Contains(
            "Contractor: Yu",
            report
        );

        Assert.Contains(
            "Hourly rate: $50.00",
            report
        );

        Assert.Contains(
            "Hours worked: 40.00",
            report
        );

        Assert.Contains(
            "Net pay: $1600.00",
            report
        );
    }

    // Polymorphism test

    [Fact]
    public void EmployeeList_CallsCorrectCalculatePayMethods()
    {
        List<Employee> employees =
            new List<Employee>
            {
                new FullTimeEmployee(
                    "Bruce",
                    75000.00m
                ),

                new Contractor(
                    "Yu",
                    50.00m,
                    40.00m
                )
            };

        Assert.Equal(
            60000.00m,
            employees[0].CalculatePay()
        );

        Assert.Equal(
            1600.00m,
            employees[1].CalculatePay()
        );
    }

}