using FantasyManager.WPF.Enums;
using FantasyManager.WPF.State.Navigators;
using System;
using System.Windows.Input;
using FantasyManager.WPF.ViewModels.Factories.Interfaces;

namespace FantasyManager.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly INavigator _navigator;
        private readonly IFantasyManagerViewModelFactory _viewModelFactory;

        public UpdateCurrentViewModelCommand(INavigator navigator, IFantasyManagerViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is ViewType viewType)
            {
                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
            }
        }
    }
}