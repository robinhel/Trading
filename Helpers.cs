namespace App;

using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

public static class Helpers
{


    public static void SaveUsersToFile(List<User> users)
    {
        string root_path = ".";
        string users_path = $"{root_path}users.json";

        string serialized = JsonSerializer.Serialize(users);
        File.WriteAllText(path: users_path, contents: serialized);
    }

    public static List<User> LoadUsersFromFile()
    {
        string root_path = ".";
        string users_path = $"{root_path}users.json";

        // Kolla om filen finns
        if (File.Exists(users_path))
        {
            // Läs in filen
            string json = File.ReadAllText(users_path);

            // Deserialisera JSON till en lista av User-objekt
            return JsonSerializer.Deserialize<List<User>>(json);

        }
        // Om filen inte finns, returnera en tom lista
        else
        {
            return new List<User>();
        }

    }

    public static void SaveAdsToFile(List<Trade> advertisements)
    {
        string root_path = ".";
        string advertisements_path = $"{root_path}advertisements.json";

        string serialized = JsonSerializer.Serialize(advertisements);
        File.WriteAllText(path: advertisements_path, contents: serialized);
    }



    public static List<Trade> LoadAdsFromFile()
    {
        string root_path = ".";
        string advertisements_path = $"{root_path}advertisements.json";

        // Kolla om filen finns
        if (File.Exists(advertisements_path))
        {
            // Läs in filen
            string json = File.ReadAllText(advertisements_path);

            // Deserialisera JSON till en lista av User-objekt
            return JsonSerializer.Deserialize<List<Trade>>(json);

        }
        // Om filen inte finns, returnera en tom lista
        else
        {
            return new List<Trade>();
        }

    }



    public static void SaveCompletedTradesToFile(List<Trade> completedTrades)
    {
        string root_path = ".";
        string completedTrades_path = $"{root_path}completedTrades.json";

        string serialized = JsonSerializer.Serialize(completedTrades);
        File.WriteAllText(path: completedTrades_path, contents: serialized);
    }


    public static List<Trade> LoadCompletedTradesFromFile()
    {
        string root_path = ".";
        string completedTrades_path = $"{root_path}completedTrades.json";

        // Kolla om filen finns
        if (File.Exists(completedTrades_path))
        {
            // Läs in filen
            string json = File.ReadAllText(completedTrades_path);

            // Deserialisera JSON till en lista av User-objekt
            return JsonSerializer.Deserialize<List<Trade>>(json);

        }
        // Om filen inte finns, returnera en tom lista
        else
        {
            return new List<Trade>();
        }

    }
}