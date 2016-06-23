using DependencyInjection.ViewFactory;
using Repository.Models.ViewModels;

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