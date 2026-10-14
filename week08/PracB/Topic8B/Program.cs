using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    private static void Main()
    {
        string folderPath = "./Attachments";
        string filePath = "./Attachments/Players.json";

        Directory.CreateDirectory(folderPath);

        // 1. Create five Player objects.
        List<Player> players = new List<Player>
        {
            new Player("Bruce", 100, 20, 10),
            new Player("Yu", 95, 25, 8),
            new Player("Tony", 110, 15, 12),
            new Player("Josh", 90, 30, 6),
            new Player("Ayo", 105, 18, 15)
        };

        Console.WriteLine("Original players:");

        foreach (Player player in players)
        {
            Console.WriteLine(player);
        }

        // 2. Convert the List<Player> into JSON.
        JsonSerializerOptions options =
            new JsonSerializerOptions
            {
                WriteIndented = true
            };

        string jsonString =
            JsonSerializer.Serialize(
                players,
                options
            );

        // 3. Print the JSON first.
        Console.WriteLine();
        Console.WriteLine("Serialised JSON:");
        Console.WriteLine(jsonString);

        // 4. Write the JSON to disk.
        File.WriteAllText(
            filePath,
            jsonString
        );

        Console.WriteLine();
        Console.WriteLine(
            $"JSON saved to {filePath}"
        );

        // 5. Read the JSON from disk.
        string loadedJson =
            File.ReadAllText(filePath);

        List<Player>? loadedPlayers =
            JsonSerializer.Deserialize<List<Player>>(
                loadedJson
            );

        Console.WriteLine();
        Console.WriteLine("Loaded players:");

        if (loadedPlayers != null)
        {
            foreach (Player player in loadedPlayers)
            {
                Console.WriteLine(player);
            }
        }
    }
}