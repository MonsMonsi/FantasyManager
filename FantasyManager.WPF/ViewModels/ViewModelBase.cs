using FantasyManager.WPF.Models.Properties;

namespace FantasyManager.WPF.ViewModels
{
    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : ViewModelBase;
    public class ViewModelBase : ObservableObject
    {
    }
}
