class Program
{
    private const double TaxRate = 0.2;

    private static void Main()
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

            double netPay = CalculatePay(hours, rate);

            Console.WriteLine(
                $"{name} earned ${netPay:F2} after tax."
            );
        }
        catch (FormatException)
        {
            Console.WriteLine(
                "Error: invalid numbers."
            );
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine(
                $"Error: {exception.Message}"
            );
        }
    }

    private static double CalculatePay(
        double hours,
        double rate
    )
    {
        if (hours < 0 || rate < 0)
        {
            throw new ArgumentException(
                "Hours and rate must be positive."
            );
        }

        double gross = hours * rate;
        double tax = gross * TaxRate;
        double net = gross - tax;

        return net;
    }
}