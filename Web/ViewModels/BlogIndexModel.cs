using System.Collections.Generic;

namespace Web.ViewModels
{
    public class BlogIndexModel
    {
        public BlogIndexModel()
        {
            Items = new List<BlogIndexItemModel>();
        }

        public IEnumerable<BlogIndexItemModel> Items { get; set; }
    }

    public class BlogIndexItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}