class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter employee name: ");
            string name = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(
                    "Employee name cannot be empty."
                );
            }

            Console.Write("Hours worked: ");
            double hours = double.Parse(
                Console.ReadLine() ?? ""
            );

            Console.Write("Hourly rate: ");
            double rate = double.Parse(
                Console.ReadLine() ?? ""
            );

            double netPay = Payroll.CalculatePay(hours, rate);

            Console.WriteLine(
                $"{name} earned ${netPay:F2} after tax."
            );
        }
        catch (FormatException)
        {
            Console.WriteLine(
                "Error: hours and hourly rate must be valid numbers."
            );
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine(
                $"Error: {exception.Message}"
            );
        }
    }
}

public static class Payroll
{
    private const double TaxRate = 0.2;

    public static double CalculatePay(
        double hours,
        double rate
    )
    {
        if (hours < 0)
        {
            throw new ArgumentException(
                "Hours worked cannot be negative."
            );
        }

        if (rate < 0)
        {
            throw new ArgumentException(
                "Hourly rate cannot be negative."
            );
        }

        double grossPay = hours * rate;
        double tax = grossPay * TaxRate;
        double netPay = grossPay - tax;

        return Math.Round(
            netPay,
            2,
            MidpointRounding.AwayFromZero
        );
    }
}