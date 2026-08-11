class Payroll
{
    private double Hours { get; set; }
    private double Rate { get; set; }
    private double TaxRate { get; set; }

    public double CalculateNetPay()
    {
        double gross = Hours * Rate;
        double tax = gross * TaxRate;
        double net = gross - tax;

        return net;
    }

    public void ChangeTaxRate(double newTaxRate)
    {
        TaxRate = newTaxRate;
    }

    public Payroll(
        double hours,
        decimal rate,
        decimal taxRate
    )
    {
        Hours = hours;
        Rate = (double)rate;
        TaxRate = (double)taxRate;

        double netPay = CalculateNetPay();

        Console.WriteLine(
            $"Net pay after tax: {netPay:F2}"
        );
    }
}