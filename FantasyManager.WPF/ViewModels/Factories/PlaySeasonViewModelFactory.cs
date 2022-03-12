using FantasyManager.WPF.ViewModels.Factories.Interfaces;

namespace FantasyManager.WPF.ViewModels.Factories
{
    public class PlaySeasonViewModelFactory : IFantasyManagerViewModelFactory<PlaySeasonViewModel>
    {
        public PlaySeasonViewModel CreateViewModel()
        {
            return new PlaySeasonViewModel();
        }
    }
}
