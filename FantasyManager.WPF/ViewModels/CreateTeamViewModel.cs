using FantasyManager.Application.Models.Data;
using FantasyManager.Application.Models.Observable;
using FantasyManager.Application.Services.Interfaces;
using FantasyManager.WPF.Commands;
using FantasyManager.WPF.Enums;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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

        public string StatusMessage { get; set; }

        #region Commands

        private AsyncRelayCommand _createUserTeamCommand;
        public ICommand CreateUserTeamCommand { get { return _createUserTeamCommand; } }
        #endregion

        private readonly ILeagueModelService _leagueService;
        private readonly ITeamModelService _teamService;
        private readonly IUserTeamModelService _userTeamModelService;

        public CreateTeamViewModel(ILeagueModelService leagueService, ITeamModelService teamService, IUserTeamModelService userTeamModelService)
        {
            _leagueService = leagueService;
            _teamService = teamService;
            _userTeamModelService = userTeamModelService;

            _createUserTeamCommand = new AsyncRelayCommand(CreateUserTeam, () => SelectedLeague != null && SelectedTeamLogo != null && UserTeamName != null && UserTeamName != "");
            _createUserTeamCommand.RaiseCanExecuteChanged();

            LoadLeagues();
            LoadTeamLogos();
        }

        private async Task CreateUserTeam()
        {
            CreationResult result = CreationResult.Success;

            UserTeamModel storedUserTeamModel = await _userTeamModelService.GetByNameAsync(UserTeamName);

            if (storedUserTeamModel is not null)
            {
                result = CreationResult.UserTeamNameAlreadyExists;
            }

            if (result == CreationResult.Success)
            {

            }
        }

        private async Task LoadLeagues()
        {
            Leagues = await _leagueService.GetAllAsync();
        }

        private async Task LoadTeamLogos()
        {
            TeamLogos = await _teamService.GetAllLogosAsync();
        }
    }
}
