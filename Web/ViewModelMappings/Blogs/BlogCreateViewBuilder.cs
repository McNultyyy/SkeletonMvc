using Web.ViewFactory;
using Web.ViewModels;
using Web.ViewModels.Blog;

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