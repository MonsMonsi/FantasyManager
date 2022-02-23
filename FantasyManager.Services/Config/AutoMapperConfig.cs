using AutoMapper;
using FantasyManager.Domain.Entities;
using FantasyManager.Services.Models.Data;

namespace FantasyManager.Services.Config
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
