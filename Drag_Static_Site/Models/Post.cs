using Drag_Static_Site.Constants;

namespace Drag_Static_Site.Models
{
    public class Post
    {
        public string   PostName          { get; set; }
        public DateTime PublishedDateTime { get; set; }
        public string   FileName          { get; set; }
        public string   Tags              { get; set; }
    }
}
