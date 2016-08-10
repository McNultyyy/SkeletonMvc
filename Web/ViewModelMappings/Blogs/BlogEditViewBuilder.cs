using Web.ViewFactory;
using Web.ViewModels;
using Web.ViewModels.Blog;

namespace Web.ViewModelMappings.Blogs
{
    public class BlogEditViewBuilder : IViewBuilder<BlogEditModel>
    {
        public BlogEditModel Build()
        {
            return new BlogEditModel();
        }
    }
}