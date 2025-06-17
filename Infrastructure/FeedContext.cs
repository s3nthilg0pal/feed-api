using System;
using System.Collections.Generic;
using Application.Common.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public partial class FeedContext : DbContext, IFeedContext
{
    public FeedContext()
    {
    }

    public FeedContext(DbContextOptions<FeedContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<ArticleTag> ArticleTags { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("articles_pkey");

            entity.ToTable("articles");

            entity.HasIndex(e => e.DeletedAt, "idx_articles_deleted_at");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Categories).HasColumnName("categories");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.Guid).HasColumnName("guid");
            entity.Property(e => e.Language).HasColumnName("language");
            entity.Property(e => e.LanguageConf).HasColumnName("language_conf");
            entity.Property(e => e.Link).HasColumnName("link");
            entity.Property(e => e.Published).HasColumnName("published");
            entity.Property(e => e.PublishedParsed).HasColumnName("published_parsed");
            entity.Property(e => e.Text).HasColumnName("text");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.Updated).HasColumnName("updated");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.UpdatedParsed).HasColumnName("updated_parsed");
        });

        modelBuilder.Entity<ArticleTag>(entity =>
        {
            entity.HasKey(e => new { e.ArticleId, e.TagId }).HasName("article_tags_pkey");

            entity.ToTable("article_tags");

            entity.Property(e => e.ArticleId).HasColumnName("article_id");
            entity.Property(e => e.TagId).HasColumnName("tag_id");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tags_pkey");

            entity.ToTable("tags");

            entity.HasIndex(e => e.DeletedAt, "idx_tags_deleted_at");

            entity.HasIndex(e => e.Name, "tags_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
