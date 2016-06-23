namespace Repository.Models.ViewModels
{
    public class BlogCreateModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public byte[] RowVersion { get; set; }
    }
}