using DependencyInjection.ViewFactory;
using Repository.Model.ViewModels;

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