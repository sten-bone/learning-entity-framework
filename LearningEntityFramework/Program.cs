using LearningEntityFramework.DbContext;
using Microsoft.EntityFrameworkCore;

namespace LearningEntityFramework;

public static class Program
{
    public static void Main()
    {
        using var db = new LearningEntityFrameworkDbContext();

        // create Blog seed data, if needed
        if (!db.Blogs.Any())
        {
            SeedData.AddBlogSeedData(db);
        }

        foreach (var b in db.Blogs.AsNoTracking())
        {
            Console.WriteLine(b.Name);
        }
    }
}