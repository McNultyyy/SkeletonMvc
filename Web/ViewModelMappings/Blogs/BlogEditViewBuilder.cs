using DependencyInjection.ViewFactory;
using Web.ViewModels;

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