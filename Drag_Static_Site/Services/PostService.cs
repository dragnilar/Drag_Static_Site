using System.Net.Http.Json;
using Drag_Static_Site.Models;
using Markdig;

namespace Drag_Static_Site.Services;

public class PostService
{
    public  List<Post>       Posts      { get; set; }
    private MarkdownPipeline MdPipeLine { get; set; }
    public async Task InitializeAsync(HttpClient client)
    {

        Posts = await client.GetFromJsonAsync<List<Post>>("posts.json");
        MdPipeLine = new MarkdownPipelineBuilder().UseYamlFrontMatter().Build();
    }

    public async Task<string> GetPostHtmlAsync(Post post, HttpClient client)
    {
        var mdContent = await client.GetStringAsync(post.FileName);
        return Markdown.ToHtml(mdContent, MdPipeLine);
    }
}