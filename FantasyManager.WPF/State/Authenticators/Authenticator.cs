using FantasyManager.Domain.Entities;
using FantasyManager.Domain.Enums;
using FantasyManager.Domain.Services;
using System;
using System.Threading.Tasks;

namespace FantasyManager.WPF.State.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;

        public Authenticator(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public User CurrentUser { get; private set; }
        public bool IsLoggedIn => CurrentUser != null;

        public async Task<bool> Login(string userName, string password)
        {
            bool success = true;

            try
            {
                User user = await _authenticationService.Login(userName, password);
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
