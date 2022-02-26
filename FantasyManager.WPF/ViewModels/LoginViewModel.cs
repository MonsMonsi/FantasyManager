using FantasyManager.Domain.Entities;
using FantasyManager.WPF.Commands;
using FantasyManager.WPF.State.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public LoginViewModel(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
            LoginCommand = new RelayCommand<object>(UserLogin);
        }

        private async void UserLogin(object parameter)
        {
            bool success = await _authenticator.Login(UserName, parameter.ToString());
        }
    }
}
