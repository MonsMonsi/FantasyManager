using AutoMapper;
using FantasyManager.Application.Models.Data;
using FantasyManager.Application.Models.Observable;
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

        public async Task<IEnumerable<PlayerDraftModel>> GetByLeagueAsDraftModelAsync(int leagueId)
        {
            var playerModels = Mapper.Map<IEnumerable<PlayerModel>>(await _playerDataService.GetByLeagueAsync(leagueId));

            var playerDraftModels = new List<PlayerDraftModel>();

            foreach (var player in playerModels)
            {
                var playerDraftModel = new PlayerDraftModel()
                {
                    Id = player.Id,
                    Image = player.Photo,
                    FullName = player.FirstName + player.LastName,
                    Position = player.Position
                };

                playerDraftModels.Add(playerDraftModel);
            }

            return playerDraftModels;
        }

        public async Task<IEnumerable<PlayerModel>> GetByLeagueAsync(int leagueId)
        {
            var players = Mapper.Map<IEnumerable<PlayerModel>>(await _playerDataService.GetByLeagueAsync(leagueId));

            return players;
        }
    }
}
