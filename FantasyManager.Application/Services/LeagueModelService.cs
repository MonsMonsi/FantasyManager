using AutoMapper;
using FantasyManager.Application.Models.Data;
using FantasyManager.Application.Services.Interfaces;
using FantasyManager.Domain.Entities;
using FantasyManager.Domain.Services;
using System.Collections.ObjectModel;

namespace FantasyManager.Application.Services
{
    public class LeagueModelService : ModelServiceBase, ILeagueModelService
    {
        private readonly IDataService<League> _leagueDataService;

        public LeagueModelService(IDataService<League> leagueDataService, IMapper mapper) : base(mapper)
        {
            _leagueDataService = leagueDataService;
        }

        public async Task<ObservableCollection<LeagueModel>> GetAllAsync()
        {
            var leagues = Mapper.Map<List<LeagueModel>>(await _leagueDataService.GetAllAsync());

            var observableLeagues = new ObservableCollection<LeagueModel>(leagues);

            return observableLeagues;
        }
    }
}
