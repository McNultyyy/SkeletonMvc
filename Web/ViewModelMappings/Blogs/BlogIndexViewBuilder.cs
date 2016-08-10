using System.Linq;
using DAL.Models.Entities;
using DAL.Repository;
using Web.ViewFactory;
using Web.ViewModels;
using Web.ViewModels.Blog;

namespace Web.ViewModelMappings.Blogs
{
    public class BlogIndexViewBuilder : IViewBuilder<BlogIndexModel>
    {
        private readonly IRepository<Blog> _repository;

        public BlogIndexViewBuilder(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public BlogIndexModel Build()
        {
            var entities = _repository.GetAll();
            var items = entities.Select(AutoMapper.Mapper.Map<Blog, BlogIndexItemModel>);
            var vm = new BlogIndexModel() { Items = items };
            return vm;
        }
    }
}