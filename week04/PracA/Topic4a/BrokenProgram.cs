namespace Topic4a;

public static class BrokenProgram
{
    static void Main(string[] args)
    {
        const string input = """
           23
           + 
           77
           + 
            3
           + 
          457
           * 
            2
             
          """;

        string[] lines = input.Split("\n");
        List<string> tokens = new List<string>();

        foreach (string line in lines)
        {
            string trimmedLine = line.Trim();

            if (trimmedLine != "")
            {
                tokens.Add(trimmedLine);
            }
        }

        int total = int.Parse(tokens[0]);

        for (int i = 1; i < tokens.Count; i += 2)
        {
            string symbol = tokens[i];
            int value = int.Parse(tokens[i + 1]);

            if (symbol == "+")
            {
                total += value;
            }
            else if (symbol == "*")
            {
                total *= value;
            }
        }

        Console.WriteLine("Total was: " + total);
        Console.WriteLine("Expected total was: 1120");
        Console.WriteLine(total == 1120
                ? "Your answer was RIGHT!"
                : "Your answer was WRONG!\nGo and fix it." );
    }
}