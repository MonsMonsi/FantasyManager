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
        public TutorialViewModel TutorialViewModel { get; set; }
        public LeagueSelectionViewModel LeagueSelectionViewModel { get; set; }
        public NameSelectionViewModel NameSelectionViewModel { get; set; }
        public LogoSelectionViewModel LogoSelectionViewModel { get; set; }

        #region OnPropertyChanged
        private IObservable<CreateTeamStep> _currentViewModel;
        public IObservable<CreateTeamStep> CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public ICommand ResetCreationCommand { get; }

        private RelayCommand _submitCreationCommand;
        public ICommand SubmitCreationCommand { get { return _submitCreationCommand; } }
        #endregion

        private IDisposable _unsubscriber;
        private Queue<string> _tutorialMessages;
        private CreateTeamStep _createTeam;
        private bool _currentStepIsComplete;

        public CreateTeamViewModel(TutorialViewModel tutorialViewModel, LeagueSelectionViewModel leagueSelectionViewModel, NameSelectionViewModel nameSelectionViewModel, LogoSelectionViewModel logoSelectionViewModel)
        {
            TutorialViewModel = tutorialViewModel;
            LeagueSelectionViewModel = leagueSelectionViewModel;
            NameSelectionViewModel = nameSelectionViewModel;
            LogoSelectionViewModel = logoSelectionViewModel;

            _createTeam = new CreateTeamStep() { CurrentStep = CreateTeamStepType.LeagueSelection };
            CurrentViewModel = LeagueSelectionViewModel;
            _unsubscriber = LeagueSelectionViewModel.Subscribe(this);

            ResetCreationCommand = new RelayCommand(OnReset);
            _submitCreationCommand = new RelayCommand(OnSubmit, () => _currentStepIsComplete);

            SetTutorialMessage();
        }

        private void SetTutorialMessage()
        {
            if (_tutorialMessages is null)
            {
                _tutorialMessages = GetTutorialMessages();
            }
            TutorialViewModel.TutorialMessage = _tutorialMessages.Dequeue();
        }

        private void OnReset()
        {

        }

        private void OnSubmit()
        {
            switch (_createTeam.CurrentStep)
            {
                case CreateTeamStepType.LeagueSelection:
                    CurrentViewModel = NameSelectionViewModel;
                    StartNextStep();
                    break;
                case CreateTeamStepType.NameSelection:
                    CurrentViewModel = LogoSelectionViewModel;
                    StartNextStep();
                    break;
                default:
                    break;
            }
        }

        private void StartNextStep()
        {
            _unsubscriber.Dispose();
            _unsubscriber = CurrentViewModel.Subscribe(this);
            _createTeam.CurrentStep = _createTeam.NextStep;
            _currentStepIsComplete = false;
            _submitCreationCommand.RaiseCanExecuteChanged();
            SetTutorialMessage();
        }

        private Queue<string> GetTutorialMessages()
        {
            var tutorials = new Queue<string>();
            tutorials.Enqueue("Choose a League to play in");
            tutorials.Enqueue("Choose a Name for your Team");
            tutorials.Enqueue("Choose your Team Logo");
            tutorials.Enqueue("Choose a Season to play in");
            return tutorials;
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
