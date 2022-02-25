using FantasyManager.Application.Services.Interfaces;
using FantasyManager.WPF.State.Navigators;
using FantasyManager.WPF.ViewModels.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.WPF.ViewModels.Factories
{
    public class LoginViewModelFactory : IFantasyManagerViewModelFactory<LoginViewModel>
    {
        private readonly IUserService _userService;
        private readonly INavigator _navigator;

        public LoginViewModelFactory(IUserService userService, INavigator navigator)
        {
            _userService = userService;
            _navigator = navigator;
        }

        public LoginViewModel CreateViewModel()
        {
            return new LoginViewModel(_userService);
        }
    }
}
