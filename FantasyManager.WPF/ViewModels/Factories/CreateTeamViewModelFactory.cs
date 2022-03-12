using FantasyManager.Application.Services.Interfaces;
using FantasyManager.WPF.ViewModels.Factories.Interfaces;

namespace FantasyManager.WPF.ViewModels.Factories
{
    public class CreateTeamViewModelFactory : IFantasyManagerViewModelFactory<CreateTeamViewModel>
    {
        private readonly ILeagueService _leagueService;
        private readonly ITeamService _teamService;

        public CreateTeamViewModelFactory(ILeagueService leagueService, ITeamService teamService)
        {
            _leagueService = leagueService;
            _teamService = teamService;
        }

        public CreateTeamViewModel CreateViewModel()
        {
            return new CreateTeamViewModel(_leagueService, _teamService);
        }
    }
}
