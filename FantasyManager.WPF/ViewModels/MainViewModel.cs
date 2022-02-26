﻿using AutoMapper;
using FantasyManager.WPF.Enums;
using FantasyManager.WPF.State.Authenticators;
using FantasyManager.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; }

        public IAuthenticator Authenticator { get; set; }

        public MainViewModel(INavigator navigator, IAuthenticator authenticator)
        {
            Navigator = navigator;
            Authenticator = authenticator;

            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Login);
        }
    }
}
