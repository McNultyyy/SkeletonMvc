﻿using DependencyInjection.ViewFactory;
using Repository.Models.Entities;
using Repository.Repositorys;
using Web.ViewModels;

namespace Web.ViewModelMappings.Blogs
{
    public class BlogDetailsViewBuilder : IViewBuilder<int, BlogDetailsModel>
    {
        private readonly IRepository<Blog> _repository;

        public BlogDetailsViewBuilder(IRepository<Blog> repository)
        {
            this._repository = repository;
        }

        public BlogDetailsModel Build(int input)
        {
            var blog = _repository.GetById(input);
            var vm = AutoMapper.Mapper.Map<BlogDetailsModel>(blog);
            return vm;
        }
    }
}