using System;
using System.Collections.Generic;

namespace Infrastructure;

public partial class Article
{
    public int Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Title { get; set; }

    public string? Text { get; set; }

    public string? Content { get; set; }

    public string? Link { get; set; }

    public string? Updated { get; set; }

    public DateTime? UpdatedParsed { get; set; }

    public string? Published { get; set; }

    public DateTime? PublishedParsed { get; set; }

    public string? Guid { get; set; }

    public string? Language { get; set; }

    public decimal? LanguageConf { get; set; }

    public string? Categories { get; set; }
}
