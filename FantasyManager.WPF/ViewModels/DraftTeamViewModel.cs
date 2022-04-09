using FantasyManager.Application.Models.Data;
using FantasyManager.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.WPF.ViewModels
{
    public class DraftTeamViewModel : ViewModelBase
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

        private ObservableCollection<PlayerModel>? _players;
        public ObservableCollection<PlayerModel>? Players
        {
            get { return _players; }
            set
            {
                _players = value;
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

        private async Task LoadPlayers()
        {
            Players = new ObservableCollection<PlayerModel>(await _playerModelService.GetByLeagueAsync(LeagueId));
        }
    }
}
