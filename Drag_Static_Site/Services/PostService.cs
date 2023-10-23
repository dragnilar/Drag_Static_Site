using System.Net.Http.Json;
using Drag_Static_Site.Models;
using Markdig;

namespace Drag_Static_Site.Services;

public class PostService
{
    public  int              LastPostIndex => Posts?.IndexOf(Posts.Last()) ?? 0;
    public  List<Post>       Posts         { get; set; }
    private MarkdownPipeline MdPipeLine    { get; set; }
    public async Task InitializeAsync(HttpClient client)
    {
        if (client == null) throw new Exception("PostService cannot be initialized with a null http client");
        Posts = await client.GetFromJsonAsync<List<Post>>("posts.json");
        if (Posts == null) throw new Exception("posts.json is missing");
        Posts = Posts.OrderByDescending(x => x.PublishedDateTime).ToList();
        MdPipeLine = new MarkdownPipelineBuilder().UseYamlFrontMatter().Build();
    }

    public async Task<string> GetPostHtmlAsync(Post post, HttpClient client)
    {
        var mdContent = await client.GetStringAsync(post.FileName);
        return Markdown.ToHtml(mdContent, MdPipeLine);
    }
    
}