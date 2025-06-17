namespace Application.Articles.GetAllArticles;

public class ArticleDto
{
    public string Title { get; set; }
    public string Content  { get; set; }
    public string Link {
        get;
        set;
    }

    public string PublishedAt { get; set; }
    public IEnumerable<TagDto> Tag { get; set; }
    public string[] Tags {
        get;
        set;
    }

    public string Text { get; set; }

    public string GeneratedOn { get; set; }
}