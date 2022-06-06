﻿using LearningEntityFramework.DbContext;
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
    }

    private static void WriteBreak()
    {
        Console.WriteLine(new string('=', 72));
    }
}