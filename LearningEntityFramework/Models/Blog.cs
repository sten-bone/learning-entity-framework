namespace LearningEntityFramework.Models;

public class Blog
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedTimestamp { get; set; }


    public Blog(string name)
    {
        ValidateBlogName(name);

        Name = name.Trim();
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