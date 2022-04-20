using FantasyManager.WPF.Enums;

namespace FantasyManager.WPF.ViewModels.Factories.Interfaces
{
    public interface IFantasyManagerViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
