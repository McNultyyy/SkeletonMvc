namespace Web.ViewModels.Blog
{
    public class BlogCreateModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public byte[] RowVersion { get; set; }
    }
}