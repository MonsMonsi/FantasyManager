
namespace FantasyManager.WPF.ViewModels.Factories.Interfaces
{
    public interface IFantasyManagerViewModelFactory<T> where T : ViewModelBase
    {
        T CreateViewModel();
    }
}
