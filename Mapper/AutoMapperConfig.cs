using Model.Entities;
using Model.ViewModels;

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
