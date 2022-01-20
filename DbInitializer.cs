namespace Contents.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(ContentsDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
