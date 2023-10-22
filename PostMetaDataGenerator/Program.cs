using System.Text.Json;
using PostMetaDataGenerator;

Console.WriteLine("Post Meta Data Generator - Generating Blog MetaData...");
Console.Write($"Using:{Environment.CurrentDirectory} for Project Root Directory");
var postDirectory = Path.Combine(Environment.CurrentDirectory, "wwwroot", "Posts");
var postFiles     = Directory.GetFiles(postDirectory).ToList();
if (postFiles.Any())
{
    var frontmatters = postFiles.Select(File.ReadAllText)
        .Select(markDownFile => markDownFile.GetFrontMatter<PostFrontMatter>()).ToList();
    var json      = JsonSerializer.Serialize<List<PostFrontMatter>>(frontmatters);
    File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "wwwroot", "posts.json"), json );
    Console.WriteLine($"{Environment.NewLine}Post Meta Data Generator -Finished Generating Blog Metadata...");
}
else
{
    Console.WriteLine($"{Environment.NewLine}Post Meta Data Generator - Skipping generating metadata, no post files found.");
}
