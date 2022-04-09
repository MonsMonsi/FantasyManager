using FantasyManager.Application.Models.Data;
using FantasyManager.Application.Models.Observable;
using FantasyManager.Application.Services.Interfaces;
using FantasyManager.WPF.Commands;
using FantasyManager.WPF.Enums;
using FantasyManager.WPF.State.Authenticators;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
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

        private readonly IAuthenticator _authenticator; 
        private readonly ILeagueModelService _leagueModelService;
        private readonly ITeamModelService _teamModelService;
        private readonly ISeasonModelService _seasonModelService;
        private readonly IUserTeamModelService _userTeamModelService;

        public CreateTeamViewModel(IAuthenticator authenticator, 
            ILeagueModelService leagueModelService, 
            ITeamModelService teamModelService, 
            ISeasonModelService seasonModelService, 
            IUserTeamModelService userTeamModelService)
        {
            _authenticator = authenticator;
            _leagueModelService = leagueModelService;
            _teamModelService = teamModelService;
            _seasonModelService = seasonModelService;
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
                var seasonModel = new SeasonModel()
                {
                    Name = UserTeamName + "_" + DateTime.Now,
                    LeagueId = SelectedLeague.Id
                };

                var createdSeason = await _seasonModelService.CreateAsync(seasonModel);

                var userTeamModel = new UserTeamModel()
                {
                    Name = UserTeamName,
                    Logo = SelectedTeamLogo.Logo,
                    IsDrafted = false,
                    UserId = _authenticator.CurrentUser.Id,
                    SeasonId = createdSeason.Id
                };

                var created = await _userTeamModelService.CreateAsync(userTeamModel);

                if (created)
                {
                    MessageBox.Show("UserTeam created");
                }
            }
        }

        private async Task LoadLeagues()
        {
            Leagues = await _leagueModelService.GetAllAsync();
        }

        private async Task LoadTeamLogos()
        {
            TeamLogos = await _teamModelService.GetAllLogosAsync();
        }
    }
}
