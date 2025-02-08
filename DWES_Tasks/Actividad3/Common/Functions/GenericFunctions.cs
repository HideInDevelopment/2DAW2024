using System.Text.Json;

namespace Actvidad3.Common.Functions;

public static class GenericFunctions
{
    public static string GetSpecificPath(string mainFolder, string subFolder)
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        
        var jsonFilePath = Path.Combine(currentDirectory, mainFolder, subFolder);
        
        return jsonFilePath;
    }

    public static void PersistInJsonFile<TEntity>(string entityPath, IEnumerable<TEntity> entityItems)
    {
        var jsonEntityItems = JsonSerializer.Serialize(entityItems);
        File.WriteAllText(entityPath, jsonEntityItems);
    }
}