using DependencyInjection.ViewFactory;
using Model.ViewModels;

namespace Mapper.ViewModelMappings.Blogs
{
    public class BlogCreateViewBuilder : IViewBuilder<BlogCreateModel>
    {
        public BlogCreateModel Build()
        {
            return new BlogCreateModel();
        }
    }
}