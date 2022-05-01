using FantasyManager.Application.Models.Observable;
using FantasyManager.Application.Services.Interfaces;
using FantasyManager.WPF.Common.Behaviors.DragDrop.Interfaces;
using FantasyManager.WPF.Common.Commands;
using FantasyManager.WPF.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FantasyManager.WPF.ViewModels.Controls
{
    public class PlayerDraftListViewModel : ViewModelBase
    {
        private int _leagueId;
        public int LeagueId
        {
            get { return _leagueId; }
            set 
            {
                _leagueId = value;

                if(_leagueId is not 0)
                    LoadPlayers();
            }
        }

        #region OnChangeProperties

        private ObservableCollection<PlayerDraftViewModel> _sortedPlayers;
        public ObservableCollection<PlayerDraftViewModel> SortedPlayers
        {
            get { return _sortedPlayers; }
            set
            {
                _sortedPlayers = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands

        public ICommand SortPlayersCommand { get; }
        #endregion

        private List<PlayerDraftViewModel> _allPlayers = new List<PlayerDraftViewModel>();

        private readonly IPlayerModelService _playerModelService;

        public PlayerDraftListViewModel(IPlayerModelService playerModelService)
        {
            _playerModelService = playerModelService;

            SortPlayersCommand = new AsyncRelayCommand<object>(SortPlayers);
        }

        private async Task SortPlayers(object parameter)
        {
            if (parameter is PlayerPositionType position)
            {
                switch (position)
                {
                    case PlayerPositionType.Goalkeeper:
                        SortedPlayers = new ObservableCollection<PlayerDraftViewModel>(_allPlayers.Where(p => p.Position == PlayerPositionType.Goalkeeper.ToString()));
                        break;
                    case PlayerPositionType.Defender:
                        SortedPlayers = new ObservableCollection<PlayerDraftViewModel>(_allPlayers.Where(p => p.Position == PlayerPositionType.Defender.ToString()));
                        break;
                    case PlayerPositionType.Midfielder:
                        SortedPlayers = new ObservableCollection<PlayerDraftViewModel>(_allPlayers.Where(p => p.Position == PlayerPositionType.Midfielder.ToString()));
                        break;
                    case PlayerPositionType.Attacker:
                        SortedPlayers = new ObservableCollection<PlayerDraftViewModel>(_allPlayers.Where(p => p.Position == PlayerPositionType.Attacker.ToString()));
                        break;
                    default:
                        break;
                }
            }
        }

        private async Task LoadPlayers()
        {
            _allPlayers.Clear();

            var playerDraftModels = new List<PlayerDraftModel>(await _playerModelService.GetByLeagueAsDraftModelAsync(LeagueId));

            foreach (var playerDraftModel in playerDraftModels)
            {
                var playerDraftViewModel = new PlayerDraftViewModel(playerDraftModel);

                _allPlayers.Add(playerDraftViewModel);
            }

            SortedPlayers = new ObservableCollection<PlayerDraftViewModel>(_allPlayers);
        }
    }
}
