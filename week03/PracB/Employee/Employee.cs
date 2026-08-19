public abstract class Employee
{
    public string Name { get; set; }

    public const decimal TaxRate = 0.2m;

    public Employee(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(
                "Employee name cannot be empty."
            );
        }

        Name = name;
    }

    public abstract decimal CalculatePay();
}