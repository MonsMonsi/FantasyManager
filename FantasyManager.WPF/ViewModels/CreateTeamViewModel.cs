using FantasyManager.Application.Enums;
using FantasyManager.Application.Models.Data;
using FantasyManager.Application.Models.Observable;
using FantasyManager.Application.Services.Interfaces;
using FantasyManager.WPF.Common.Commands;
using FantasyManager.WPF.Enums;
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
    public class CreateTeamViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; set; }
        public TutorialViewModel TutorialViewModel { get; set; }

        #region OnChangeProperties

        private LeagueSelectionViewModel _leagueSelectionViewModel;
        public LeagueSelectionViewModel LeagueSelectionViewModel
        {
            get { return _leagueSelectionViewModel; }
            set
            {
                _leagueSelectionViewModel = value;
                OnPropertyChanged();
                if (_submitCreationCommand is not null)
                {
                    _submitCreationCommand.RaiseCanExecuteChanged();
                }
            }
        }
        #endregion

        #region Commands

        public ICommand ResetCreationCommand { get; }

        private RelayCommand _submitCreationCommand;
        public ICommand SubmitCreationCommand { get { return _submitCreationCommand; } }
        #endregion

        private List<string> _tutorialMessages;

        public CreateTeamViewModel(TutorialViewModel tutorialViewModel, LeagueSelectionViewModel leagueSelectionViewModel)
        {
            TutorialViewModel = tutorialViewModel;
            LeagueSelectionViewModel = leagueSelectionViewModel;

            CurrentViewModel = LeagueSelectionViewModel;

            ResetCreationCommand = new RelayCommand(ResetCreation);
            _submitCreationCommand = new RelayCommand(SubmitCreation, IsSubmittable);

            LoadTutorialMessages();

            TutorialViewModel.TutorialMessage = _tutorialMessages[0];
        }

        private void ResetCreation()
        {

        }

        private void SubmitCreation()
        {

        }

        private bool IsSubmittable()
        {
            if (CurrentViewModel is LeagueSelectionViewModel leagueSelection)
            {
                return leagueSelection.SelectedLeague is not null;
            }
            return false;
        }

        private void LoadTutorialMessages()
        {
            _tutorialMessages = new List<string>();
            _tutorialMessages.Add("Choose a League to play in");
            _tutorialMessages.Add("Choose a Name for your Team");
            _tutorialMessages.Add("Choose your Team Logo");
            _tutorialMessages.Add("Choose a Season to play in");
        }
    }
}
