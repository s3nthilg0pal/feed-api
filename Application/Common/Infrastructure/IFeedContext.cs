using System.Collections.Generic;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Infrastructure;

public interface IFeedContext
{ 
    DbSet<Article> Articles { get; set; }

    DbSet<ArticleTag> ArticleTags { get; set; }

    DbSet<Tag> Tags { get; set; }
}