using AutoMapper;

namespace FantasyManager.Application.Services
{
    public abstract class ModelServiceBase
    {
        protected readonly IMapper Mapper;

        public ModelServiceBase(IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}
