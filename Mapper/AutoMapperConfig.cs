﻿using Repository.Models.Entities;
using Repository.Models.ViewModels;

namespace Mapper
{
    public static class AutoMapperConfig
    {
        public static void RegisterMapping()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Blog, BlogIndexItemModel>().ReverseMap();
                config.CreateMap<Blog, BlogCreateModel>().ReverseMap();
                config.CreateMap<Blog, BlogEditModel>().ReverseMap();
                config.CreateMap<Blog, BlogDetailsModel>().ReverseMap();
            });
        }
    }
}
