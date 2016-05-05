using AutoMapper;
using Model.Entities;

namespace Model
{
    public static class AutoMapperConfig
    {
        public static void RegisterMapping()
        {
            var mapper = new MapperConfiguration(config =>
                config.CreateMap<Employee, Employee>()
            );
        }
    }
}
