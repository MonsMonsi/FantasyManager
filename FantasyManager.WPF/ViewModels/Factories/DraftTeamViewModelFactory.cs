using FantasyManager.Application.Services.Interfaces;
using FantasyManager.WPF.ViewModels.Factories.Interfaces;

namespace FantasyManager.WPF.ViewModels.Factories
{
    public class DraftTeamViewModelFactory : IFantasyManagerViewModelFactory<DraftTeamViewModel>
    {
        private readonly IPlayerModelService _playerModelService;

        public DraftTeamViewModelFactory(IPlayerModelService playerModelService)
        {
            _playerModelService = playerModelService;
        }

        public DraftTeamViewModel CreateViewModel()
        {
            return new DraftTeamViewModel(_playerModelService);
        }
    }
}
