using System.Text.Json;

Console.WriteLine("Generating Blog MetaData...");
Console.Write($"Using:{Environment.CurrentDirectory} for Project Root Directory");
var postDirectory = Path.Combine(Environment.CurrentDirectory, "wwwroot\\Posts\\");
var postFiles     = Directory.GetFiles(postDirectory).ToList();
if (postFiles.Any())
{
    var fileNames = postFiles.Select(Path.GetFileName).ToList();
    var json      = JsonSerializer.Serialize<List<string>>(fileNames);
    File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "wwwroot\\posts.json"), json );
    Console.WriteLine("Finished Generating Blog Metadata...");
}
else
{
    Console.WriteLine("Skipping generating metadata, no post files found.");
}
