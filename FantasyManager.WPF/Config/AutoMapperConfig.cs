using AutoMapper;
using FantasyManager.Domain.Entities;
using FantasyManager.WPF.Models.Data;

namespace FantasyManager.WPF.Config
{
    public static class AutoMapperConfig
    {
        public static IMapper ConfigureAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserModel, User>().ReverseMap();
            });

            return config.CreateMapper();
        }
    }
}
