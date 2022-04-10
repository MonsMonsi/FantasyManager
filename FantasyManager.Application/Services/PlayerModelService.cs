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

        public async Task<IEnumerable<PlayerListViewItemModel>> GetByLeagueAsListViewItemAsync(int leagueId)
        {
            var players = Mapper.Map<IEnumerable<PlayerModel>>(await _playerDataService.GetByLeagueAsync(leagueId));

            var playersAsListViewItem = new List<PlayerListViewItemModel>();

            foreach (var player in players)
            {
                // TODO: Klasse für Header und SubHeader -> handling wäre viel besser
                var playerAsListViewItem = new PlayerListViewItemModel()
                {
                    Id = player.Id,
                    Image = player.Photo,
                    Header = new List<string>()
                    {
                        player.FirstName,
                        player.LastName,
                        player.Position
                    },
                    SubHeader = new List<string>()
                    {
                        player.Position
                    }
                };

                playersAsListViewItem.Add(playerAsListViewItem);
            }

            return playersAsListViewItem;
        }

        public async Task<IEnumerable<PlayerModel>> GetByLeagueAsync(int leagueId)
        {
            var players = Mapper.Map<IEnumerable<PlayerModel>>(await _playerDataService.GetByLeagueAsync(leagueId));

            return players;
        }
    }
}
