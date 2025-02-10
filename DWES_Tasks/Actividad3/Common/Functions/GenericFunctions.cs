using System.Text.Json;

namespace Actividad3.Common.Functions;

public static class GenericFunctions
{
    public static string GetSpecificPath(string pathFromSolutionRoot) => Path.GetFullPath(pathFromSolutionRoot);
}