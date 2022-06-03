namespace LearningEntityFramework.Models;

public class Blog
{
    public int BlogId { get; set; }
    public string Name { get; set; }
    public DateTime CreatedTimestamp { get; set; }

    public List<Post> Posts { get; set; } = new();


    public Blog(string name, DateTime createdTimestamp)
    {
        ValidateBlogName(name);

        Name = name.Trim();
        CreatedTimestamp = createdTimestamp;
    }

    private static void ValidateBlogName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new Exception("Blog name cannot be empty");
        }

        if (name.Length > 100)
        {
            throw new Exception("Blog name must be less than 100 characters.");
        }
    }
}