using System.Text.Json;

namespace Actvidad3.Common.Functions;

public static class GenericFunctions
{
    public static string? GetSpecificPath(string mainFolder, string subFolder)
    {
        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        
        var potentialPath= Path.Combine(baseDirectory, mainFolder, subFolder);
        
        return Directory.Exists(potentialPath) ? potentialPath : SearchForDirectory(baseDirectory, mainFolder, subFolder);
    }

    private static string? SearchForDirectory(string baseDirectory, string mainFolder, string subFolder)
    {
        try
        {
            foreach (var directory in Directory.GetDirectories(baseDirectory, mainFolder, SearchOption.AllDirectories))
            {
                var fullPath = Path.Combine(directory, subFolder);
                
                if(Directory.Exists(fullPath))
                    return fullPath;
            }
        }
        catch (UnauthorizedAccessException)
        {
            return null;
        }

        return null;
    }
}