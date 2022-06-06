using LearningEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningEntityFramework.DbContext.EntityTypeConfigurations;

internal class BlogEntityTypeConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.ToTable("Blogs");
        builder.HasKey(x => x.BlogId);

        builder.Property(x => x.BlogId).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.CreatedTimestamp);

        builder.Metadata.FindNavigation(nameof(Blog.Posts))!.SetPropertyAccessMode(PropertyAccessMode.Field);
        builder.HasMany(b => b.Posts).WithOne().HasForeignKey(x => x.BlogId).OnDelete(DeleteBehavior.Cascade);
    }
}