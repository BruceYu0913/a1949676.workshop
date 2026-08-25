using System.Globalization;

namespace Topic4a
{
    internal static class BrokenProgram
    {
        private const int ExpectedTotal = 1120;

        private static readonly Dictionary<string, string> Resources = new()
        {
            ["RightAnswer"] = "Your answer was RIGHT!",
            ["WrongAnswer"] = "Your answer was WRONG!\nGo and fix it."
        };

        private static void Main()
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

            List<string> tokens = ExtractTokens(input);
            int total = CalculateTotal(tokens);

            PrintResult(total);
        }

        private static List<string> ExtractTokens(
            string input
        )
        {
            string[] lines = input.Split('\n');
            List<string> tokens = [];

            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();

                if (!string.IsNullOrEmpty(trimmedLine))
                {
                    tokens.Add(trimmedLine);
                }
            }

            return tokens;
        }

        private static int CalculateTotal(
            List<string> tokens
        )
        {
            int total = int.Parse(
                tokens[0],
                CultureInfo.InvariantCulture
            );

            for (int i = 1; i < tokens.Count; i += 2)
            {
                string symbol = tokens[i];

                int value = int.Parse(
                    tokens[i + 1],
                    CultureInfo.InvariantCulture
                );

                if (symbol == "+")
                {
                    total += value;
                }
                else if (symbol == "*")
                {
                    total *= value;
                }
                else
                {
                    throw new InvalidOperationException(
                        "Unsupported symbol: " + symbol
                    );
                }
            }

            return total;
        }

        private static void PrintResult(int total)
        {
            string totalMessage =
                "Total was: " + total;

            string expectedMessage =
                "Expected total was: " + ExpectedTotal;

            string resultMessage =
                total == ExpectedTotal
                                        ? Resources["RightAnswer"]
                                        : Resources["WrongAnswer"];

            Console.WriteLine(totalMessage);
            Console.WriteLine(expectedMessage);
            Console.WriteLine(resultMessage);
        }
    }
}