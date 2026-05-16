using System.Text.Json;
using CV.Models;

namespace CV.IO;

public class JsonLoader
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = true
    };

    public CVData Load(string inputPath)
    {
        var json = File.ReadAllText(inputPath);
        return JsonSerializer.Deserialize<CVData>(json, _options)!;
    }

    public void Save(string outputPath, CVData data)
    {
        var dir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrEmpty(dir))
            Directory.CreateDirectory(dir);

        var json = JsonSerializer.Serialize(data, _options);
        File.WriteAllText(outputPath, json);
    }
}