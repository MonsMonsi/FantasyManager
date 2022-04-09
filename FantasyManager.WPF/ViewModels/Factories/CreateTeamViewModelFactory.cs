using FantasyManager.Application.Services.Interfaces;
using FantasyManager.WPF.State.Authenticators;
using FantasyManager.WPF.ViewModels.Factories.Interfaces;

namespace FantasyManager.WPF.ViewModels.Factories
{
    public class CreateTeamViewModelFactory : IFantasyManagerViewModelFactory<CreateTeamViewModel>
    {
        private readonly IAuthenticator _authenticator;
        private readonly ILeagueModelService _leagueService;
        private readonly ITeamModelService _teamService;
        private readonly ISeasonModelService _seasonService;
        private readonly IUserTeamModelService _userTeamModelService;

        public CreateTeamViewModelFactory(IAuthenticator authenticator, ILeagueModelService leagueService, ITeamModelService teamService, ISeasonModelService seasonModelService, IUserTeamModelService userTeamModelService)
        {
            _authenticator = authenticator;
            _leagueService = leagueService;
            _teamService = teamService;
            _seasonService = seasonModelService;
            _userTeamModelService = userTeamModelService;
        }

        public CreateTeamViewModel CreateViewModel()
        {
            return new CreateTeamViewModel(_authenticator, _leagueService, _teamService, _seasonService, _userTeamModelService);
        }
    }
}
