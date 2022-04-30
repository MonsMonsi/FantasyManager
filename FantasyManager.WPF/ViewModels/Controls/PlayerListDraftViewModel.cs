using FantasyManager.Application.Models.Observable;
using FantasyManager.Application.Models.Observable.Interfaces;
using FantasyManager.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.WPF.ViewModels.Controls
{
    public class PlayerListDraftViewModel : ViewModelBase, IDragable, IDropable
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

        private ObservableCollection<PlayerListViewItemModel> _sortedPlayers;
        public ObservableCollection<PlayerListViewItemModel> SortedPlayers
        {
            get { return _sortedPlayers; }
            set
            {
                _sortedPlayers = value;
                OnPropertyChanged();
            }
        }
        #endregion

        private List<PlayerListViewItemModel> _allPlayers;

        private readonly IPlayerModelService _playerModelService;

        public PlayerListDraftViewModel(IPlayerModelService playerModelService)
        {
            _playerModelService = playerModelService;

            LeagueId = 39;

            LoadPlayers();
        }

        #region IDragable

        Type IDragable.DataType => typeof(PlayerListViewItemModel);
        public void Remove(object i)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region IDropable

        Type IDropable.DataType => typeof(PlayerListViewItemModel);
        public void Drop(object data, int index = -1)
        {
            throw new NotImplementedException();
        }
        #endregion

        private async Task LoadPlayers()
        {
            _allPlayers = new List<PlayerListViewItemModel>(await _playerModelService.GetByLeagueAsListViewItemAsync(LeagueId));

            SortedPlayers = new ObservableCollection<PlayerListViewItemModel>(_allPlayers);
        }
    }
}
