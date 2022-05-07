using FantasyManager.Application.Models.Data;
using FantasyManager.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.WPF.ViewModels.Controls
{
    public class LeagueSelectionViewModel : ViewModelBase
    {
        #region OnChangeProperties

        private ObservableCollection<LeagueModel> _leagues;
        public ObservableCollection<LeagueModel> Leagues
        {
            get { return _leagues; }
            set
            {
                _leagues = value;
                OnPropertyChanged();
            }
        }

        private LeagueModel _selectedLeague;
        public LeagueModel SelectedLeague
        {
            get { return _selectedLeague; }
            set
            {
                _selectedLeague = value;
                OnPropertyChanged();
            }
        }
        #endregion

        private readonly ILeagueModelService _leagueModelService;

        public LeagueSelectionViewModel(ILeagueModelService leagueModelService)
        {
            _leagueModelService = leagueModelService;

            LoadLeagues();
        }

        private async Task LoadLeagues()
        {
            Leagues = new ObservableCollection<LeagueModel>(await _leagueModelService.GetAllAsync());
        }
    }
}
