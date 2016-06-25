using Web.ViewFactory;
using Web.ViewModels;

namespace Web.ViewModelMappings.Blogs
{
    public class BlogCreateViewBuilder : IViewBuilder<BlogCreateModel>
    {
        public BlogCreateModel Build()
        {
            return new BlogCreateModel();
        }
    }
}