using System.Text.Json;
using PostMetaDataGenerator;

Console.WriteLine("Post Meta Data Generator - Generating Blog MetaData...");
Console.Write($"Using:{Environment.CurrentDirectory} for Project Root Directory");
var postDirectory = Path.Combine(Environment.CurrentDirectory, "wwwroot", "Posts");
var postFiles     = Directory.GetFiles(postDirectory).ToList();
if (postFiles.Any())
{
    List<PostFrontMatter> frontMatters = new List<PostFrontMatter>();
    foreach (var postFile in postFiles)
    {
        var newFrontMatter = File.ReadAllText(postFile).GetFrontMatter<PostFrontMatter>();
        newFrontMatter.FileName = $"Posts/{Path.GetFileName(postFile)}";
        frontMatters.Add(newFrontMatter);
    }
    var json      = JsonSerializer.Serialize<List<PostFrontMatter>>(frontMatters);
    File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "wwwroot", "posts.json"), json );
    Console.WriteLine($"{Environment.NewLine}Post Meta Data Generator -Finished Generating Blog Metadata...");
}
else
{
    Console.WriteLine($"{Environment.NewLine}Post Meta Data Generator - Skipping generating metadata, no post files found.");
}
