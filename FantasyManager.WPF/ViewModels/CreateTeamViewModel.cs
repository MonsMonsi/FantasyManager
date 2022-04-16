using FantasyManager.Application.Enums;
using FantasyManager.Application.Models.Data;
using FantasyManager.Application.Models.Observable;
using FantasyManager.Application.Services.Interfaces;
using FantasyManager.WPF.Common.Commands;
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

        private string _leaguesFeatureHeader;
        public string LeaguesFeatureHeader
        {
            get { return _leaguesFeatureHeader; }
            set
            {
                _leaguesFeatureHeader = value;
                OnPropertyChanged();
            }
        }
        #endregion

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

            LeaguesFeatureHeader = "Choose a League!";

            _createUserTeamCommand = new AsyncRelayCommand(CreateUserTeam, () => SelectedLeague != null && SelectedTeamLogo != null && UserTeamName != null && UserTeamName != "");
            _createUserTeamCommand.RaiseCanExecuteChanged();

            LoadLeagues();
            LoadTeamLogos();
        }

        private async Task CreateUserTeam()
        {
            // TODO: Funktion überdenken -> wo soll die Validierung stattfinden?
            CreationResult result;

            var storedUserTeam = await _userTeamModelService.GetByNameAsync(UserTeamName);

            if (storedUserTeam is null)
            {
                // TODO: Season soll gewählt werden können, nicht jedes Mal neue erstellen!
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

                result = await _userTeamModelService.CreateAsync(userTeamModel);
            }
            else
            {
                result = CreationResult.UserTeamNameAlreadyExists;
            }

            if (result is CreationResult.UserTeamNameAlreadyExists)
            {
                MessageBox.Show("UserTeamName already exists");
            }

            if (result is CreationResult.Success)
            {
                MessageBox.Show("UserTeam created");
            }
        }

        private async Task LoadLeagues()
        {
            Leagues = new ObservableCollection<LeagueModel>(await _leagueModelService.GetAllAsync());
        }

        private async Task LoadTeamLogos()
        {
            TeamLogos = new ObservableCollection<TeamLogoModel>(await _teamModelService.GetAllLogosAsync());
        }
    }
}
