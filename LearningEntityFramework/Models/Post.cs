namespace LearningEntityFramework.Models;

public class Post
{
    public int PostId { get; set; }
    public int BlogId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime CreatedDate { get; set; }
    public int Likes { get; protected set; } = 0;
    public int Dislikes { get; protected set; } = 0;

    public Post(string title, string body)
    {
        ValidatePostTitle(title);
        if (string.IsNullOrWhiteSpace(body))
        {
            throw new Exception("Post cannot have empty body");
        }

        Title = title;
        Body = body;
    }

    public void ValidatePostTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new Exception("Post title cannot be empty");
        }

        if (title.Length > 150)
        {
            throw new Exception("Post title must be less than 150 characters.");
        }
    }

    public void Like(int numberOfLikes = 1) => Likes += numberOfLikes;
    public void Dislike(int numberOfDislikes) => Dislikes += numberOfDislikes;
}