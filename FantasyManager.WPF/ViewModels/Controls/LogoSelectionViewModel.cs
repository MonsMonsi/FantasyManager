using FantasyManager.Application.Models.Observable;
using FantasyManager.Application.Services.Interfaces;
using FantasyManager.WPF.Common.IObservable;
using FantasyManager.WPF.Enums;
using FantasyManager.WPF.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.WPF.ViewModels.Controls
{
    public class LogoSelectionViewModel : ViewModelBase, IObservable<CreateTeamStep>
    {
        List<IObserver<CreateTeamStep>> _observers;

        #region OnChangeProperties
        private ObservableCollection<TeamLogoModel> _teamLogos;
        public ObservableCollection<TeamLogoModel> TeamLogos
        {
            get => _teamLogos;
            set
            {
                _teamLogos = value;
                OnPropertyChanged();
            }
        }

        private TeamLogoModel _selectedTeamLogo;
        public TeamLogoModel SelectedTeamLogo
        {
            get => _selectedTeamLogo;
            set
            {
                _selectedTeamLogo = value;
                OnLogoSubmitted();
                OnPropertyChanged();
            }
        }
        #endregion

        private readonly ITeamModelService _teamModelService;

        public LogoSelectionViewModel(ITeamModelService teamModelService)
        {
            _teamModelService = teamModelService;
            _observers = new List<IObserver<CreateTeamStep>>();

            LoadTeamLogos();
        }

        private async Task LoadTeamLogos()
        {
            TeamLogos = new ObservableCollection<TeamLogoModel>(await _teamModelService.GetAllLogosAsync());
        }


        #region IObservable
        public void OnLogoSubmitted()
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(new CreateTeamStep()
                {
                    CurrentStep = CreateTeamStepType.LogoSelection,
                    NextStep = CreateTeamStepType.SeasonSelection,
                    IsSubmitted = SelectedTeamLogo is not null
                });
            }
        }

        public IDisposable Subscribe(IObserver<CreateTeamStep> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);

            return new Unsubscriber<CreateTeamStep>(_observers, observer);
        }
        #endregion
    }
}
