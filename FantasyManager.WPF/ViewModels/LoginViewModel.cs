using FantasyManager.WPF.Commands;
using FantasyManager.WPF.Enums;
using FantasyManager.Application.Models.Data;
using FantasyManager.Application.Services.Interfaces;
using FantasyManager.WPF.State.Navigators;
using System.Windows;
using System.Windows.Input;

namespace FantasyManager.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        #region Properties

        private UserModel _userInput;
        public UserModel UserInput
        {
            get { return _userInput; }
            set
            {
                _userInput = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand LoginCommand { get; set; }
        public ICommand NewUserCommand { get; set; }

        #endregion

        #region Fields

        // private readonly INavigator _navigator;
        private readonly IUserService _userService;

        #endregion

        public LoginViewModel(IUserService userService)
        {
            // _navigator = navigator;
            _userService = userService;
            UserInput = new();
            LoginCommand = new RelayCommand<object>(CheckLogin);
            NewUserCommand = new RelayCommand<object>(NewUser);
        }

        #region Methods

        private async void CheckLogin(object parameter)
        {
            var success = false;

            UserModel userFromDb;

            if (UserInput.Name != null && UserInput.Password != null)
            {
                userFromDb = await _userService.Login(UserInput);

                if (userFromDb != null)
                {
                    success = true;
                }
            };

            if (success)
            {
                MessageBox.Show("You logged in");
                // _navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Home);
            }
            else
            {
                MessageBox.Show("Username or Password incorrect");
            }
        }

        private async void NewUser(object parameter)
        {
            var success = false;

            UserModel userFromDb;

            if (UserInput.Name != null && UserInput.Password != null) 
            {
                userFromDb = await _userService.AddNew(UserInput);

                if (userFromDb != null)
                {
                    success = true;
                }
            };

            if (success)
            {
                MessageBox.Show("New User was created");
                // _navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Home);
            }
            else
            {
                MessageBox.Show("Username already in use");
            }
        }

        #endregion
    }
}
