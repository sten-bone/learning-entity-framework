using LearningEntityFramework.DbContext;
using LearningEntityFramework.Models;

namespace LearningEntityFramework;

public static class SeedData
{
    public static void AddBlogSeedData(LearningEntityFrameworkDbContext db)
    {
        var blogA = new Blog("Blog A", new DateTime(2022, 2, 18, 12, 27, 23));
        blogA.AddPost(new Post("How to 1", "Thing 1")
        {
            CreatedDate = new DateTime(2022, 2, 18, 14, 42, 35)
        });
        blogA.AddPost(new Post("How to 2", "Thing 2")
        {
            CreatedDate = new DateTime(2022, 2, 24, 9, 2, 56)
        });
        blogA.Posts[0].Like(numberOfLikes: 100);
        blogA.Posts[0].Dislike(numberOfDislikes: 0);
        blogA.Posts[1].Like(numberOfLikes: 127);
        blogA.Posts[1].Dislike(numberOfDislikes: 3);

        var blogB = new Blog("Blog B", new DateTime(2022, 4, 3, 20, 31, 17));
        blogB.AddPost(new Post("I Hate X", "X is the worst.")
        {
            CreatedDate = new DateTime(2022, 4, 4, 11, 24, 1)
        });
        blogB.AddPost(new Post("I Hate Y", "Y is the worst.")
        {
            CreatedDate = new DateTime(2022, 4, 4, 11, 59, 50)
        });
        blogB.AddPost(new Post("I Hate Z", "Z is the worst.")
        {
            CreatedDate = new DateTime(2022, 4, 5, 13, 22, 41)
        });
        blogB.Posts[0].Like(numberOfLikes: 2194);
        blogB.Posts[0].Dislike(numberOfDislikes: 412);
        blogB.Posts[1].Like(numberOfLikes: 657);
        blogB.Posts[1].Dislike(numberOfDislikes: 8914);
        blogB.Posts[2].Like(numberOfLikes: 1467);
        blogB.Posts[2].Dislike(numberOfDislikes: 125);

        db.Add(blogA);
        db.Add(blogB);
        db.SaveChanges();
    }

    public static Blog CreateRandomBlog(int numberPosts)
    {
        var blog = new Blog("A randomly generated blog", DateTime.Now);

        var rand = new Random();

        for (var i = 1; i <= numberPosts; i++)
        {
            blog.AddPost(CreateRandomPost($"Random post #{i:D2}", "XYZ", rand.Next(10000), rand.Next(10000)));
        }

        return blog;
    }

    public static Post CreateRandomPost(string title, string body, int numLikes, int numDislikes)
    {
        var post = new Post(title, body)
        {
            CreatedDate = DateTime.Now
        };
        post.Like(numberOfLikes: numLikes);
        post.Dislike(numberOfDislikes: numDislikes);
        return post;
    }
}