using FantasyManager.WPF.ViewModels.Factories.Interfaces;

namespace FantasyManager.WPF.ViewModels.Factories
{
    public class DraftTeamViewModelFactory : IFantasyManagerViewModelFactory<DraftTeamViewModel>
    {
        public DraftTeamViewModel CreateViewModel()
        {
            return new DraftTeamViewModel();
        }
    }
}
