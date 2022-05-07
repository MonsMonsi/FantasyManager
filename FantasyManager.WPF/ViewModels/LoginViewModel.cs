using FantasyManager.WPF.Common.Commands;
using FantasyManager.WPF.State.Authenticators;
using FantasyManager.WPF.State.Navigators;
using System.Threading.Tasks;
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
            LoginCommand = new AsyncRelayCommand<object>(UserLogin);
        }

        private async Task UserLogin(object parameter)
        {
            bool success = await _authenticator.Login(UserName, parameter.ToString());

            if (success)
            {
                _renavigator.Renavigate();
            }
        }
    }
}
