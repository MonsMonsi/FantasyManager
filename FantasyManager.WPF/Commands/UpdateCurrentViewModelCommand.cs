using FantasyManager.WPF.Enums;
using FantasyManager.WPF.State.Navigators;
using FantasyManager.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FantasyManager.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly INavigator _navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;

                switch (viewType)
                {
                    case ViewType.Main:
                        _navigator.CurrentViewModel = new MainViewModel();
                        break;
                    case ViewType.Home:
                        _navigator.CurrentViewModel = new HomeViewModel();
                        break;
                    case ViewType.CreateTeam:
                        _navigator.CurrentViewModel = new CreateTeamViewModel();
                        break;
                    case ViewType.DraftTeam:
                        _navigator.CurrentViewModel = new DraftTeamViewModel();
                        break;
                    case ViewType.PlaySeason:
                        _navigator.CurrentViewModel = new PlaySeasonViewModel();
                        break;
                }
            }
        }
    }
}