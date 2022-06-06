using LearningEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningEntityFramework.DbContext.EntityTypeConfigurations;

public class BlogLogoEntityTypeConfiguration : IEntityTypeConfiguration<BlogLogo>
{
    public void Configure(EntityTypeBuilder<BlogLogo> builder)
    {
        builder.ToTable("BlogLogos");
        builder.HasKey(x => x.BlogLogoId);

        builder.Property(x => x.BlogLogoId).ValueGeneratedOnAdd();
        builder.Property(x => x.Image);
        builder.Property(x => x.Caption);
    }
}