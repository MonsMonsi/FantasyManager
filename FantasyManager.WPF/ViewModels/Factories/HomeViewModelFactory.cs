using FantasyManager.WPF.ViewModels.Factories.Interfaces;

namespace FantasyManager.WPF.ViewModels.Factories
{
    public class HomeViewModelFactory : IFantasyManagerViewModelFactory<HomeViewModel>
    {
        public HomeViewModel CreateViewModel()
        {
            return new HomeViewModel();
        }
    }
}
