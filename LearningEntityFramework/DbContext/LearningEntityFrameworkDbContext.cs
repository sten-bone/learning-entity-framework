using LearningEntityFramework.DbContext.EntityTypeConfigurations;
using LearningEntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningEntityFramework.DbContext;

public class LearningEntityFrameworkDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    internal string DbPath { get; }
    internal DbSet<Blog> Blogs { get; set; } = null!;

    public LearningEntityFrameworkDbContext()
    {
        var dataFolder = Path.Combine("C:", "AppData", "LearningEntityFramework");
        DbPath = Path.Combine(dataFolder, "learning.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}");
        options.EnableSensitiveDataLogging();
        options.EnableDetailedErrors();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BlogEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new PostEntityTypeConfiguration());
    }
}