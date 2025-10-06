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

    public static void SaveAdsToFile(List<Trade> advertisements)
    {
        string root_path = ".";
        string advertisements_path = $"{root_path}advertisements.json";

        string serialized = JsonSerializer.Serialize(advertisements);
        File.WriteAllText(path: advertisements_path, contents: serialized);
    }

    public static void SaveCompleteTradesToFile(List<Trade> completedTrades)
    {
        string root_path = ".";
        string completedTrades_path = $"{root_path}completedTrades.json";

        string serialized = JsonSerializer.Serialize(completedTrades);
        File.WriteAllText(path: completedTrades_path, contents: serialized);
    }
}