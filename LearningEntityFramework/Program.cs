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

        // don't track changes
        foreach (var b in db.Blogs.AsNoTracking())
        {
            Console.WriteLine(b.Name);
        }

        WriteBreak();

        // query eager
        foreach (var x in db.Blogs.Include(x => x.Posts).AsNoTracking())
        {
            Console.WriteLine($"Blog {x.Name}");
            foreach (var p in x.Posts)
            {
                Console.WriteLine($"\t{p.Title}");
            }
        }

        WriteBreak();

        // same query, but explicitly loaded
        foreach (var x in db.Blogs)
        {
            Console.WriteLine($"Blog {x.Name}");
            foreach (var p in db.Entry(x).Collection(b => b.Posts).Query().AsNoTracking())
            {
                Console.WriteLine($"\t{p.Title}");
            }
        }

        WriteBreak();

        // same query, but with raw SQL
        foreach (var x in db.Blogs.FromSqlRaw("SELECT * FROM Blogs").Include(x => x.Posts).AsNoTracking())
        {
            Console.WriteLine($"Blog {x.Name}");
            foreach (var p in x.Posts)
            {
                Console.WriteLine($"\t{p.Title}");
            }
        }

        WriteBreak();

        var posts = db.Posts.AsNoTracking();
        for (var i = 1; i <= 5; i++)
        {
            var p = posts.Single(x => x.PostId == i);
            Console.WriteLine($"Post {i}: {p.Title} ({p.Likes} {(p.Likes == 1 ? "Like" : "Likes")}, {p.Dislikes} {(p.Dislikes == 1 ? "Dislike" : "Dislikes")})");
        }

        WriteBreak();

        // add 3 new blogs
        var newBlogA = SeedData.CreateRandomBlog(7);
        var newBlogB = SeedData.CreateRandomBlog(10);
        var newBlogC = SeedData.CreateRandomBlog(4);

        db.Add(newBlogA);
        db.Add(newBlogB);
        db.Add(newBlogC);
        db.SaveChanges();

        PrintAllBlogs(db);
        WriteBreak();

        // update some details
        newBlogA.Name = "New Blog A";
        newBlogB.RemovePostAt(2);
        newBlogC.Posts[0].Title = "Updated title";
        db.SaveChanges();

        PrintAllBlogs(db);
        WriteBreak();

        // remove blogs
        db.Remove(newBlogA);
        db.Remove(newBlogB);
        db.Remove(newBlogC);
        db.SaveChanges();

        PrintAllBlogs(db);
        WriteBreak();
    }

    private static void WriteBreak()
    {
        Console.WriteLine(new string('=', 72));
    }

    private static void PrintAllBlogs(LearningEntityFrameworkDbContext db)
    {
        foreach (var x in db.Blogs.Include(x => x.Posts).AsNoTracking())
        {
            Console.WriteLine($"Blog {x.Name}");
            foreach (var p in x.Posts)
            {
                Console.WriteLine($"\t{p.Title} ({p.Likes} {(p.Likes == 1 ? "Like" : "Likes")}, {p.Dislikes} {(p.Dislikes == 1 ? "Dislike" : "Dislikes")})");
            }
        }
    }
}