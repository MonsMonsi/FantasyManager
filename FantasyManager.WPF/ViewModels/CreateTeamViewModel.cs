using FantasyManager.Application.Models;
using FantasyManager.Application.Services.Interfaces;
using System.Collections.ObjectModel;

namespace FantasyManager.WPF.ViewModels
{
    public class CreateTeamViewModel : ViewModelBase
    {
        #region OnChangeProperties

        private ObservableCollection<LeagueModel>? _leagues;
        public ObservableCollection<LeagueModel>? Leagues
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

        private string _userTeamName;
        public string UserTeamName
        {
            get { return _userTeamName; }
            set
            {
                _userTeamName = value;
                OnPropertyChanged();
            }
        }

        #endregion

        private readonly ILeagueService _leagueService;

        public CreateTeamViewModel(ILeagueService leagueService)
        {
            _leagueService = leagueService;
            LoadLeagues();
        }

        private async void LoadLeagues()
        {
            Leagues = await _leagueService.GetAllAsync();
        }
    }
}
