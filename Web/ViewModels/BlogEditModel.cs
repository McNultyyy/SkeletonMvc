namespace Repository.Models.ViewModels
{
    public class BlogEditModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public byte[] RowVersion { get; set; }
    }
}