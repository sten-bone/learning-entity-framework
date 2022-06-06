using LearningEntityFramework.DbContext;
using LearningEntityFramework.Models;

namespace LearningEntityFramework;

public static class SeedData
{
    public static void AddBlogSeedData(LearningEntityFrameworkDbContext db)
    {
        var blogA = new Blog("Blog A", new DateTime(2022, 2, 18, 12, 27, 23))
        {
            Posts = new List<Post>
            {
                new("How to 1", "Thing 1")
                {
                    CreatedDate = new DateTime(2022, 2, 18, 14, 42, 35)
                },
                new("How to 2", "Thing 2")
                {
                    CreatedDate = new DateTime(2022, 2, 24, 9, 2, 56)
                }
            }
        };
        blogA.Posts[0].LikePostNTimes(100);
        blogA.Posts[0].DislikePostNTimes(0);
        blogA.Posts[1].LikePostNTimes(127);
        blogA.Posts[1].DislikePostNTimes(3);

        var blogB = new Blog("Blog B", new DateTime(2022, 4, 3, 20, 31, 17))
        {
            Posts = new List<Post>
            {
                new("I Hate X", "X is the worst.")
                {
                    CreatedDate = new DateTime(2022, 4, 4, 11, 24, 1)
                },
                new("I Hate Y", "Y is the worst.")
                {
                    CreatedDate = new DateTime(2022, 4, 4, 11, 59, 50)
                },
                new("I Hate Z", "Z is the worst.")
                {
                    CreatedDate = new DateTime(2022, 4, 5, 13, 22, 41)
                }
            }
        };
        blogB.Posts[0].LikePostNTimes(2194);
        blogB.Posts[0].DislikePostNTimes(412);
        blogB.Posts[1].LikePostNTimes(657);
        blogB.Posts[1].DislikePostNTimes(8914);
        blogB.Posts[2].LikePostNTimes(1467);
        blogB.Posts[2].DislikePostNTimes(125);

        db.Add(blogA);
        db.Add(blogB);
        db.SaveChanges();
    }

    private static void LikePostNTimes(this Post p, int n)
    {
        foreach (var x in Enumerable.Range(0, n))
        {
            p.Like();
        }
    }

    private static void DislikePostNTimes(this Post p, int n)
    {
        foreach (var x in Enumerable.Range(0, n))
        {
            p.Dislike();
        }
    }

    public static Blog CreateRandomBlog(int numberPosts)
    {
        var blog = new Blog("A randomly generated blog", DateTime.Now)
        {
            Posts = new List<Post>()
        };

        var rand = new Random();

        for (var i = 1; i <= numberPosts; i++)
        {
            blog.Posts.Add(CreateRandomPost($"Random post #{i:D2}", "XYZ", rand.Next(10000), rand.Next(10000)));
        }

        return blog;
    }

    public static Post CreateRandomPost(string title, string body, int numLikes, int numDislikes)
    {
        var post = new Post(title, body)
        {
            CreatedDate = DateTime.Now
        };
        post.LikePostNTimes(numLikes);
        post.DislikePostNTimes(numDislikes);
        return post;
    }
}