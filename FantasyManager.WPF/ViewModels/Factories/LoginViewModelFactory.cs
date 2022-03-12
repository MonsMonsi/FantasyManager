using FantasyManager.WPF.State.Authenticators;
using FantasyManager.WPF.State.Navigators;
using FantasyManager.WPF.ViewModels.Factories.Interfaces;

namespace FantasyManager.WPF.ViewModels.Factories
{
    public class LoginViewModelFactory : IFantasyManagerViewModelFactory<LoginViewModel>
    {
        private readonly IAuthenticator _authenticator;

        private readonly IRenavigator _renavigator;

        public LoginViewModelFactory(IAuthenticator authenticator, IRenavigator renavigator)
        {
            _authenticator = authenticator;
            _renavigator = renavigator;
        }

        public LoginViewModel CreateViewModel()
        {
            return new LoginViewModel(_authenticator, _renavigator);
        }
    }
}
