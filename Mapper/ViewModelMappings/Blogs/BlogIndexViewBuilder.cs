﻿using System.Linq;
using DependencyInjection.ViewFactory;
using Model.Entities;
using Model.ViewModels;
using Repository;

namespace Mapper.ViewModelMappings.Blogs
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