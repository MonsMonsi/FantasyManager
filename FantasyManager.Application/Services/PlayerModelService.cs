using AutoMapper;
using FantasyManager.Application.Models.Data;
using FantasyManager.Application.Services.Interfaces;
using FantasyManager.Domain.Services;

namespace FantasyManager.Application.Services
{
    public class PlayerModelService : ModelServiceBase, IPlayerModelService
    {
        private readonly IPlayerService _playerDataService;

        public PlayerModelService(IPlayerService playerDataService, IMapper mapper) : base(mapper)
        {
            _playerDataService = playerDataService;
        }

        public async Task<IEnumerable<PlayerModel>> GetByLeagueAsync(int leagueId)
        {
            var players = Mapper.Map<IEnumerable<PlayerModel>>(await _playerDataService.GetByLeagueAsync(leagueId));

            return players;
        }
    }
}
