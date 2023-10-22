using Drag_Static_Site.Constants;

namespace Drag_Static_Site.Models
{
    public class Post
    {
        public Post(string postName, DateTime publishedDateTime, string fileName)
        {
            PostName = postName;
            PublishedDateTime = publishedDateTime;
            _fileName = fileName;
        }
        public  string   PostName          { get; set; }
        public  DateTime PublishedDateTime { get; set; }
        public  string   FileName          => "Posts/" + _fileName;
        private string   _fileName;

        public async Task<string> GetMarkDownContentAsync(HttpClient client)
        {
            return await client.GetStringAsync(FileName);
        }
    }
}
