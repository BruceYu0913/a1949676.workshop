public class FullTimeEmployee
    : Employee, IReportable
{
    public decimal AnnualSalary { get; set; }

    public FullTimeEmployee(
        string name,
        decimal annualSalary
    ) : base(name)
    {
        if (annualSalary < 0)
        {
            throw new ArgumentException(
                "Annual salary cannot be negative."
            );
        }

        AnnualSalary = annualSalary;
    }

    public override decimal CalculatePay()
    {
        decimal tax = AnnualSalary * TaxRate;
        decimal netPay = AnnualSalary - tax;

        return netPay;
    }

    public string GenerateReport()
    {
        string report =
            $"Full-time employee: {Name}\n" +
            $"Annual salary: ${AnnualSalary:F2}\n" +
            $"Net annual pay: ${CalculatePay():F2}";

        Console.WriteLine(report);

        return report;
    }
}