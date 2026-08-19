public class Contractor
    : Employee, IReportable
{
    public decimal Rate { get; set; }
    public decimal Hours { get; set; }

    public Contractor(
        string name,
        decimal rate,
        decimal hours
    ) : base(name)
    {
        if (rate < 0)
        {
            throw new ArgumentException(
                "Rate cannot be negative."
            );
        }

        if (hours < 0)
        {
            throw new ArgumentException(
                "Hours cannot be negative."
            );
        }

        Rate = rate;
        Hours = hours;
    }

    public override decimal CalculatePay()
    {
        decimal grossPay = Rate * Hours;
        decimal tax = grossPay * TaxRate;
        decimal netPay = grossPay - tax;

        return netPay;
    }

    public string GenerateReport()
    {
        string report =
            $"Contractor: {Name}\n" +
            $"Hourly rate: ${Rate:F2}\n" +
            $"Hours worked: {Hours:F2}\n" +
            $"Net pay: ${CalculatePay():F2}";

        Console.WriteLine(report);

        return report;
    }
}