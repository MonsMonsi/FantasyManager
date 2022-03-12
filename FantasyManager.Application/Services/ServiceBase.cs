using AutoMapper;

namespace FantasyManager.Application.Services
{
    public abstract class ServiceBase
    {
        protected readonly IMapper Mapper;

        public ServiceBase(IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}
