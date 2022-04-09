using FantasyManager.Domain.Entities;
using FantasyManager.Domain.Enums;
using FantasyManager.Domain.Services;
using FantasyManager.WPF.Models.Properties;
using System;
using System.Threading.Tasks;

namespace FantasyManager.WPF.State.Authenticators
{
    public class Authenticator : ObservableObject, IAuthenticator
    {
        private User _currentUser;
        public User CurrentUser
        {
            get { return _currentUser; }
            private set
            {
                _currentUser = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsLoggedIn));
            }
        }

        public bool IsLoggedIn => CurrentUser != null;


        private readonly IAuthenticationService _authenticationService;

        public Authenticator(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<bool> Login(string userName, string password)
        {
            bool success = true;

            try
            {
                CurrentUser = await _authenticationService.Login(userName, password);
            }
            catch (Exception)
            {
                success = false;
            }

            return success;
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        public async Task<RegistrationResult> Register(string userName, string password, string confirmPassword, string email)
        {
            return await _authenticationService.Register(userName, password, confirmPassword, email);
        }
    }
}
