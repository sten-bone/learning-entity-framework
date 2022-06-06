namespace LearningEntityFramework.Models;

public class Blog
{
    public int BlogId { get; set; }
    public string Name { get; set; }
    public DateTime CreatedTimestamp { get; set; }
    private readonly List<Post> _posts = new();
    public IReadOnlyList<Post> Posts => _posts;


    public Blog(string name, DateTime createdTimestamp)
    {
        ValidateBlogName(name);

        Name = name.Trim();
        CreatedTimestamp = createdTimestamp;
    }

    public void AddPost(Post p)
    {
        _posts.Add(p);
    }

    public void RemovePostAt(int index)
    {
        if (index >= _posts.Count)
        {
            throw new IndexOutOfRangeException($"Index {index} is out of range!");
        }
        _posts.RemoveAt(index);
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