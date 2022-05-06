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

        private ObservableCollection<PlayerDraftModel> _sortedPlayers;
        public ObservableCollection<PlayerDraftModel> SortedPlayers
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

        private List<PlayerDraftModel> _allPlayers = new List<PlayerDraftModel>();

        private readonly IPlayerModelService _playerModelService;

        public PlayerDraftListViewModel(IPlayerModelService playerModelService)
        {
            _playerModelService = playerModelService;

            SortPlayersCommand = new AsyncRelayCommand<object>(SortPlayers);
        }

        public void RemovePlayerFromList(PlayerDraftModel player)
        {
            _allPlayers.Remove(player);

            UpdateObservableCollection();
        }

        private async Task SortPlayers(object parameter)
        {
            if (parameter is PlayerPositionType position)
            {
                switch (position)
                {
                    case PlayerPositionType.Goalkeeper:
                         await UpdateObservableCollection(position.ToString());
                        break;
                    case PlayerPositionType.Defender:
                        await UpdateObservableCollection(position.ToString());
                        break;
                    case PlayerPositionType.Midfielder:
                        await UpdateObservableCollection(position.ToString());
                        break;
                    case PlayerPositionType.Attacker:
                        await UpdateObservableCollection(position.ToString());
                        break;
                    default:
                        break;
                }
            }
        }

        private async Task UpdateObservableCollection(string position = "")
        {
            if (position is "")
            {
                SortedPlayers = new ObservableCollection<PlayerDraftModel>(_allPlayers);
            }
            else
            {
                SortedPlayers = new ObservableCollection<PlayerDraftModel>(_allPlayers.Where(p => p.Position == position));    
            }
        }

        private async Task LoadPlayers()
        {
            _allPlayers.Clear();

            _allPlayers = new List<PlayerDraftModel>(await _playerModelService.GetByLeagueAsDraftModelAsync(LeagueId));

            await UpdateObservableCollection();
        }
    }
}
