using AutoMapper;
using FantasyManager.Application.Models.Data;
using FantasyManager.Application.Services.Interfaces;
using FantasyManager.Domain.Entities;
using FantasyManager.Domain.Services;
using System.Collections.ObjectModel;

namespace FantasyManager.Application.Services
{
    public class LeagueService : ServiceBase, ILeagueService
    {
        private readonly IDataService<League> _leagueService;

        public LeagueService(IDataService<League> leagueService, IMapper mapper) : base(mapper)
        {
            _leagueService = leagueService;
        }

        public async Task<ObservableCollection<LeagueModel>> GetAllAsync()
        {
            var leagues = Mapper.Map<List<LeagueModel>>(await _leagueService.GetAllAsync());

            var observableLeagues = new ObservableCollection<LeagueModel>(leagues);

            return observableLeagues;
        }
    }
}
