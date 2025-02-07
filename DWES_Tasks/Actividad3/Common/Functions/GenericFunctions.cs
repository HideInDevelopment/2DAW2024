namespace Actvidad3.Common.Functions;

public static class GenericFunctions
{
    public static string GetSpecificPath(string mainFolder, string subFolder)
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        
        var jsonFilePath = Path.Combine(currentDirectory, mainFolder, subFolder);
        
        return jsonFilePath;
    }
}