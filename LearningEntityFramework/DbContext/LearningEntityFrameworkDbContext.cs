using LearningEntityFramework.DbContext.EntityTypeConfigurations;
using LearningEntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningEntityFramework.DbContext;

public class LearningEntityFrameworkDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    internal string DbPath { get; }
    internal DbSet<Blog> Blogs { get; set; } = null!;
    internal DbSet<Post> Posts { get; set; } = null!;

    public LearningEntityFrameworkDbContext()
    {
        var dataFolder = Path.Combine("C:", "AppData", "LearningEntityFramework");
        DbPath = Path.Combine(dataFolder, "learning.db");

        // create DB if it does not yet exist
        var dbFile = new FileInfo(DbPath);
        if (!dbFile.Exists)
        {
            dbFile.Create();
            Console.WriteLine("You need to update the database with `dotnet ef database update`");
            Environment.Exit(1);
        }
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