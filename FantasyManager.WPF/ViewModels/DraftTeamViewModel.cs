using FantasyManager.Application.Models.Data;
using FantasyManager.Application.Models.Observable;
using FantasyManager.Application.Services.Interfaces;
using FantasyManager.WPF.Common.Behaviors.DragDrop.Interfaces;
using FantasyManager.WPF.Common.Commands;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FantasyManager.WPF.ViewModels
{
    public class DraftTeamViewModel : ViewModelBase, IDragable
    {
        #region OnChangeProperties

        private int _leagueId;
        public int LeagueId
        {
            get { return _leagueId; }
            set
            {
                _leagueId = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<PlayerListViewItemModel>? _players;
        public ObservableCollection<PlayerListViewItemModel>? Players
        {
            get { return _players; }
            set
            {
                _players = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region IDragable Members

        Type IDragable.DataType
        {
            get { return typeof(DraftTeamViewModel); }
        }
        #endregion

        #region Commands

        private ICommand _onPlayerDroppedCommand;
        public ICommand OnPlayerDroppedCommand 
        {
            get { return _onPlayerDroppedCommand ?? (_onPlayerDroppedCommand = new RelayCommand<object>(OnPlayerDropped)); }
            set
            {
                _onPlayerDroppedCommand = value;
                OnPropertyChanged();
            }
        }
        #endregion

        private readonly IPlayerModelService _playerModelService;

        public DraftTeamViewModel(IPlayerModelService playerModelService)
        {
            _playerModelService = playerModelService;

            LeagueId = 39;

            LoadPlayers();
        }

        private void OnPlayerDropped(object parameter)
        {
            var test = parameter.ToString();
        }

        private async Task LoadPlayers()
        {
            Players = new ObservableCollection<PlayerListViewItemModel>(await _playerModelService.GetByLeagueAsListViewItemAsync(LeagueId));
        }

        public void Remove(object i)
        {
            throw new System.NotImplementedException();
        }
    }
}
