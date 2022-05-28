using FantasyManager.Application.Enums;
using FantasyManager.Application.Models.Data;
using FantasyManager.Application.Models.Observable;
using FantasyManager.Application.Services.Interfaces;
using FantasyManager.WPF.Common.Commands;
using FantasyManager.WPF.Enums;
using FantasyManager.WPF.Messages;
using FantasyManager.WPF.State.Authenticators;
using FantasyManager.WPF.ViewModels.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FantasyManager.WPF.ViewModels
{
    public class CreateTeamViewModel : ViewModelBase, IObserver<CreateTeamStep>
    {
        public ViewModelBase CurrentViewModel { get; set; }
        public TutorialViewModel TutorialViewModel { get; set; }
        public LeagueSelectionViewModel LeagueSelectionViewModel { get; set; }

        #region Commands
        public ICommand ResetCreationCommand { get; }

        private RelayCommand _submitCreationCommand;
        public ICommand SubmitCreationCommand { get { return _submitCreationCommand; } }
        #endregion

        private IDisposable _unsubscriber;
        private List<string> _tutorialMessages;
        private CreateTeamStep _createTeam;
        private bool _currentStepIsComplete;

        public CreateTeamViewModel(TutorialViewModel tutorialViewModel, LeagueSelectionViewModel leagueSelectionViewModel)
        {
            TutorialViewModel = tutorialViewModel;
            LeagueSelectionViewModel = leagueSelectionViewModel;

            _createTeam = new CreateTeamStep() { CurrentStep = CreateTeamStepType.LeagueSelection };
            CurrentViewModel = LeagueSelectionViewModel;
            _unsubscriber = LeagueSelectionViewModel.Subscribe(this);

            ResetCreationCommand = new RelayCommand(OnReset);
            _submitCreationCommand = new RelayCommand(OnSubmit, () => _currentStepIsComplete);

            LoadTutorialMessages();

            SetTutorialMessage();
        }

        private void SetTutorialMessage()
        {

        }

        private void OnReset()
        {

        }

        private void OnSubmit()
        {
            switch (_createTeam.CurrentStep)
            {
                case CreateTeamStepType.LeagueSelection:
                    CurrentViewModel = null;
                    break;
                case CreateTeamStepType.NameSelection:
                    break;
                default:
                    break;
            }
        }

        private void LoadTutorialMessages()
        {
            _tutorialMessages = new List<string>();
            _tutorialMessages.Add("Choose a League to play in");
            _tutorialMessages.Add("Choose a Name for your Team");
            _tutorialMessages.Add("Choose your Team Logo");
            _tutorialMessages.Add("Choose a Season to play in");
        }

        #region IObserver
        public void OnCompleted()
        {
            // IDisposable
        }

        public void OnError(Exception error)
        {
            // not to implement
        }

        public void OnNext(CreateTeamStep value)
        {
            if(value is not null)
                _createTeam = value;

            _currentStepIsComplete = _createTeam.IsSubmitted;

            _submitCreationCommand.RaiseCanExecuteChanged();
        }
        #endregion
    }
}
