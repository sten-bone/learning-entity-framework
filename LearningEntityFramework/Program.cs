using LearningEntityFramework.DbContext;

namespace LearningEntityFramework;

public static class Program
{
    public static void Main()
    {
        SeedData.AddBlogSeedData();
    }
}