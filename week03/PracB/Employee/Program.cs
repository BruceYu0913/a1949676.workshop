class Program
{
    private static void Main()
    {
        try
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

            foreach (Employee employee in employees)
            {
                decimal netPay =
                    employee.CalculatePay();

                decimal grossPay =
                    netPay / (1 - Employee.TaxRate);

                decimal tax =
                    grossPay - netPay;

                Console.WriteLine(
                    $"{employee.Name}: " +
                    $"Pay ${netPay:F2}. " +
                    $"Tax ${tax:F2}."
                );
            }
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine(
                $"Error: {exception.Message}"
            );
        }
    }
}