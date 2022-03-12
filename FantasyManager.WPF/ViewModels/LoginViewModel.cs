using FantasyManager.WPF.Commands;
using FantasyManager.WPF.State.Authenticators;
using FantasyManager.WPF.State.Navigators;
using System.Windows.Input;

namespace FantasyManager.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; set; }

        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;

        public LoginViewModel(IAuthenticator authenticator, IRenavigator renavigator)
        {
            _authenticator = authenticator;
            _renavigator = renavigator;
            LoginCommand = new RelayCommand<object>(UserLogin);
        }

        private async void UserLogin(object parameter)
        {
            bool success = await _authenticator.Login(UserName, parameter.ToString());

            if (success)
            {
                _renavigator.Renavigate();
            }
        }
    }
}
