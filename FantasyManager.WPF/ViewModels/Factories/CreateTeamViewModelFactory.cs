using FantasyManager.Application.Services.Interfaces;
using FantasyManager.WPF.ViewModels.Factories.Interfaces;

namespace FantasyManager.WPF.ViewModels.Factories
{
    public class CreateTeamViewModelFactory : IFantasyManagerViewModelFactory<CreateTeamViewModel>
    {
        private readonly ILeagueModelService _leagueService;
        private readonly ITeamModelService _teamService;
        private readonly IUserTeamModelService _userTeamModelService;

        public CreateTeamViewModelFactory(ILeagueModelService leagueService, ITeamModelService teamService, IUserTeamModelService userTeamModelService)
        {
            _leagueService = leagueService;
            _teamService = teamService;
            _userTeamModelService = userTeamModelService;
        }

        public CreateTeamViewModel CreateViewModel()
        {
            return new CreateTeamViewModel(_leagueService, _teamService, _userTeamModelService);
        }
    }
}
