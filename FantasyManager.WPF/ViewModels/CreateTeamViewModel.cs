using FantasyManager.Application.Models.Data;
using FantasyManager.Application.Models.Observable;
using FantasyManager.Application.Services.Interfaces;
using FantasyManager.WPF.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

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
                _createUserTeamCommand.RaiseCanExecuteChanged();
            }
        }

        private ObservableCollection<TeamLogoModel>? _teamLogos;
        public ObservableCollection<TeamLogoModel>? TeamLogos
        {
            get { return _teamLogos; }
            set
            {
                _teamLogos = value;
                OnPropertyChanged();
            }
        }

        private TeamLogoModel _selectedTeamLogo;
        public TeamLogoModel SelectedTeamLogo
        {
            get { return _selectedTeamLogo; }
            set
            {
                _selectedTeamLogo = value;
                OnPropertyChanged();
                _createUserTeamCommand.RaiseCanExecuteChanged();
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
                _createUserTeamCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion

        #region Commands

        private RelayCommand _createUserTeamCommand;
        public ICommand CreateUserTeamCommand { get { return _createUserTeamCommand; } }
        #endregion

        private readonly ILeagueService _leagueService;
        private readonly ITeamService _teamService;

        public CreateTeamViewModel(ILeagueService leagueService, ITeamService teamService)
        {
            _leagueService = leagueService;
            _teamService = teamService;

            _createUserTeamCommand = new RelayCommand(CreateUserTeam, () => SelectedLeague != null && SelectedTeamLogo != null && UserTeamName != "");

            LoadLeagues();
            LoadTeamLogos();
        }

        private void CreateUserTeam()
        {

        }

        private async void LoadLeagues()
        {
            Leagues = await _leagueService.GetAllAsync();
        }

        private async void LoadTeamLogos()
        {
            TeamLogos = await _teamService.GetAllLogosAsync();
        }
    }
}
