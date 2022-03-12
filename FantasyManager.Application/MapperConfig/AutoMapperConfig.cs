using AutoMapper;
using FantasyManager.Domain.Entities;
using FantasyManager.Application.Models.Data;

namespace FantasyManager.Application.MapperConfig
{
    public static class AutoMapperConfig
    {
        public static IMapper ConfigureAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserModel, User>().ReverseMap();
                cfg.CreateMap<LeagueModel, League>().ReverseMap();
                cfg.CreateMap<TeamModel, Team>().ReverseMap();
            });

            return config.CreateMapper();
        }
    }
}
