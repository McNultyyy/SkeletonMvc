using DependencyInjection.ViewFactory;
using Model.ViewModels;

namespace Mapper.ViewModelMappings.Blogs
{
    public class BlogEditViewBuilder : IViewBuilder<BlogEditModel>
    {
        public BlogEditModel Build()
        {
            return new BlogEditModel();
        }
    }
}