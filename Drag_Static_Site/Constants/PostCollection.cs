using Drag_Static_Site.Models;

namespace Drag_Static_Site.Constants;

public class PostCollection
{
    public List<Post> Posts;

    public PostCollection()
    {
        InitializePosts();
    }

    private void InitializePosts()
    {
        Posts = new List<Post>
        {
            new("Post Zero", new DateTime(2023, 10, 21), "10212023.md"),
            new("First Post", new DateTime(2023, 10, 22), "10222023.md"),
            new("Second", new DateTime(2023, 10, 23), "10232023.md")
        }.OrderByDescending(x => x.PublishedDateTime).ToList();
    }
}