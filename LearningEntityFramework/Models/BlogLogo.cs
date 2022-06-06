namespace LearningEntityFramework.Models;

public class BlogLogo
{
    public int BlogLogoId { get; set; }
    public int BlogId { get; set; }
    public byte[] Image { get; set; } = Array.Empty<byte>();
    public string Caption { get; set; }

    public BlogLogo(string caption)
    {
        ValidateBlogLogoCaption(caption);

        Caption = caption.Trim();
    }

    private static void ValidateBlogLogoCaption(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new Exception("Blog logo caption cannot be empty");
        }
    }
}