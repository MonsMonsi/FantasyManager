using FantasyManager.Application.Services.Interfaces;
using FantasyManager.WPF.ViewModels.Factories.Interfaces;

namespace FantasyManager.WPF.ViewModels.Factories
{
    public class CreateTeamViewModelFactory : IFantasyManagerViewModelFactory<CreateTeamViewModel>
    {
        private readonly ILeagueModelService _leagueService;
        private readonly ITeamModelService _teamService;

        public CreateTeamViewModelFactory(ILeagueModelService leagueService, ITeamModelService teamService)
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
