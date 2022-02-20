using FantasyManager.WPF.Commands;
using FantasyManager.WPF.Enums;
using FantasyManager.WPF.Models.Data;
using FantasyManager.WPF.Services.Interfaces;
using FantasyManager.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FantasyManager.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        #region Properties

        private string _username;
        public string UserName
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        private string _userPassword;
        public string UserPassword
        {
            get { return _userPassword; }
            set
            {
                _userPassword = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand LoginCommand { get; set; }
        public ICommand NewUserCommand { get; set; }

        #endregion

        #region Fields

        private readonly INavigator _navigator;
        private readonly IUserService _userService;

        #endregion

        public LoginViewModel(IUserService userService, INavigator navigator)
        {
            _navigator = navigator;
            _userService = userService;
            LoginCommand = new RelayCommand<object>(CheckLogin);
            NewUserCommand = new RelayCommand<object>(NewUser);
        }

        #region Methods

        private async void CheckLogin(object parameter)
        {
            UserModel inputUser = new();

            if (UserName != null && UserPassword != null)
            {
                inputUser.Name = UserName;
                inputUser.Password = UserPassword;
            }

            var success = false;

            UserModel userFromDb = new();

            if (inputUser != null)
            {
                userFromDb = await _userService.Login(inputUser);

                if (userFromDb != null)
                {
                    success = true;
                }
            };

            if (success)
            {
                MessageBox.Show("You logged in");
                _navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Home);
            }
            else
            {
                MessageBox.Show("Username or Password incorrect");
            }
        }

        private async void NewUser(object parameter)
        {
            UserModel inputUser = new();

            if (UserName != null && UserPassword != null)
            {
                inputUser.Name = UserName;
                inputUser.Password = UserPassword;
            }

            var success = false;

            UserModel userFromDb = new();

            if (inputUser != null)
            {
                userFromDb = await _userService.AddNew(inputUser);

                if (userFromDb != null)
                {
                    success = true;
                }
            };

            if (success)
            {
                MessageBox.Show("New User was created");
                _navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Home);
            }
            else
            {
                MessageBox.Show("Username already in use");
            }
        }

        #endregion
    }
}
