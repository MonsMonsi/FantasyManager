using FantasyManager.WPF.Commands;
using FantasyManager.WPF.Enums;
using FantasyManager.WPF.State.Authenticators;
using FantasyManager.WPF.State.Navigators;
using FantasyManager.WPF.ViewModels.Factories.Interfaces;
using System.Windows.Input;

namespace FantasyManager.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IFantasyManagerViewModelAbstractFactory _viewModelfactory;

        public INavigator Navigator { get; set; }
        public IAuthenticator Authenticator { get; set; }
        public ICommand UpdateCurrentViewModelCommand { get; }

        public MainViewModel(INavigator navigator, IAuthenticator authenticator, IFantasyManagerViewModelAbstractFactory viewModelfactory)
        {
            Navigator = navigator;
            Authenticator = authenticator;
            _viewModelfactory = viewModelfactory;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelfactory);
            // zu Login zurückändern!!!
            UpdateCurrentViewModelCommand.Execute(ViewType.Login);
        }
    }
}
