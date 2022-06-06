using LearningEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningEntityFramework.DbContext.EntityTypeConfigurations;

public class PostEntityTypeConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts");
        builder.HasKey(x => x.PostId);

        builder.Property(x => x.PostId).ValueGeneratedOnAdd();
        builder.Property(x => x.BlogId);
        builder.Property(x => x.Title).HasMaxLength(150);
        builder.Property(x => x.Body);
        builder.Property(x => x.CreatedDate);
        builder.Property(x => x.Likes);
        builder.Property(x => x.Dislikes);
    }
}