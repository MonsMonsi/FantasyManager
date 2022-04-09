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

        public async Task<IEnumerable<LeagueModel>> GetAllAsync()
        {
            var leagues = Mapper.Map<IEnumerable<LeagueModel>>(await _leagueDataService.GetAllAsync());

            return leagues;
        }
    }
}
