class Program
{
    private static void Main()
    {
        try
        {
            FullTimeEmployee fullTimeEmployee =
                new FullTimeEmployee(
                    "Bruce",
                    75000.00m
                );

            Contractor contractor =
                new Contractor(
                    "Yu",
                    50.00m,
                    40.00m
                );

            Console.WriteLine("FULL-TIME EMPLOYEE");

            fullTimeEmployee.GenerateReport();

            Console.WriteLine(
                $"CalculatePay result: " +
                $"${fullTimeEmployee.CalculatePay():F2}"
            );

            Console.WriteLine();

            Console.WriteLine("CONTRACTOR");

            contractor.GenerateReport();

            Console.WriteLine(
                $"CalculatePay result: " +
                $"${contractor.CalculatePay():F2}"
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