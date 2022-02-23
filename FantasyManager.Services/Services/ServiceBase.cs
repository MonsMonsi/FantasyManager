using AutoMapper;
using FantasyManager.Data;

namespace FantasyManager.Services.Services
{
    public abstract class ServiceBase : IDisposable
    {
        protected readonly FootballContext Context;
        protected readonly IMapper Mapper;

        public ServiceBase(FootballContextFactory contextFactory, IMapper mapper)
        {
            Context = contextFactory.CreateDbContext();
            Mapper = mapper;
        }

        private bool _disposed = false;
        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            Context.Dispose();
        }
    }
}
