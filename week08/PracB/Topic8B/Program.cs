using System.Diagnostics;
using System.Text.Json;

class Program
{
    private static void Main()
    {
        string path = "./Attachments/Players.json";

        /*
        List<Player> players = new List<Player>();

        for (int i = 0; i < 10000; i++)
        {
            players.Add(
                new Player($"Player{i + 1}")
            );
        }

        FileWriter(path, players);

        List<Player> loadedPlayers =
            FileReader<List<Player>>(path);

        Console.WriteLine(
            $"List count: {loadedPlayers.Count}"
        );

        GC.Collect();

        Console.WriteLine(
            $"List HeapSizeBytes: " +
            $"{GC.GetGCMemoryInfo().HeapSizeBytes}"
        );

        Console.WriteLine(
            $"List PeakWorkingSet64: " +
            $"{Process.GetCurrentProcess().PeakWorkingSet64}"
        );

        GC.KeepAlive(players);
        GC.KeepAlive(loadedPlayers);
        */


        LinkedList<Player> players =
            new LinkedList<Player>();

        for (int i = 0; i < 10000; i++)
        {
            players.AddLast(
                new Player($"Player{i + 1}")
            );
        }

        FileWriter(path, players);

        LinkedList<Player> loadedPlayers =
            FileReader<LinkedList<Player>>(path);

        Console.WriteLine(
            $"LinkedList count: {loadedPlayers.Count}"
        );

        GC.Collect();

        Console.WriteLine(
            $"LinkedList HeapSizeBytes: " +
            $"{GC.GetGCMemoryInfo().HeapSizeBytes}"
        );

        Console.WriteLine(
            $"LinkedList PeakWorkingSet64: " +
            $"{Process.GetCurrentProcess().PeakWorkingSet64}"
        );

        GC.KeepAlive(players);
        GC.KeepAlive(loadedPlayers);
    }

    public static void FileWriter<T>(
        string path,
        T objectToWrite
    )
        where T : class
    {
        string jsonString =
            JsonSerializer.Serialize(objectToWrite);

        File.WriteAllText(path, jsonString);
    }

    public static T FileReader<T>(
        string path
    )
        where T : class
    {
        string jsonString =
            File.ReadAllText(path);

        return JsonSerializer.Deserialize<T>(
            jsonString
        )!;
    }
}