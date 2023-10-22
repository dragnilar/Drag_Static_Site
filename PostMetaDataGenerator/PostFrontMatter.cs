using YamlDotNet.Serialization;

namespace PostMetaDataGenerator;

public class PostFrontMatter
{
    [YamlMember(Alias = "tags")]
    public string Tags { get; set; }
    
    [YamlMember(Alias = "title")]
    public string PostName { get; set; }
    [YamlMember(Alias = "published")]
    public DateTime PublishedDateTime { get; set; }
    [YamlMember(Alias = "fileName")]
    public string FileName { get; set; }
    
    [YamlIgnore]
    public IList<string> GetTags => Tags?
        .Split(",", StringSplitOptions.RemoveEmptyEntries)
        .Select(x => x.Trim())
        .ToArray();
}