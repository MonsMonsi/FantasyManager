using FantasyManager.WPF.Enums;

namespace FantasyManager.WPF.ViewModels.Factories.Interfaces
{
    public interface IFantasyManagerViewModelAbstractFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
