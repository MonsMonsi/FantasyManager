using FantasyManager.Application.Models.Data;
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
    public class LeagueSelectionViewModel : ViewModelBase, IObservable<CreateTeamStep>
    {
        List<IObserver<CreateTeamStep>> _observers;

        #region OnChangeProperties
        private ObservableCollection<LeagueModel> _leagues;
        public ObservableCollection<LeagueModel> Leagues
        {
            get => _leagues; 
            set
            {
                _leagues = value;
                OnPropertyChanged();
            }
        }

        private LeagueModel _selectedLeague;
        public LeagueModel SelectedLeague
        {
            get => _selectedLeague; 
            set
            {
                _selectedLeague = value;
                OnLeagueSubmitted();
                OnPropertyChanged();
            }
        }
        #endregion

        private readonly ILeagueModelService _leagueModelService;

        public LeagueSelectionViewModel(ILeagueModelService leagueModelService)
        {
            _leagueModelService = leagueModelService;

            _observers = new List<IObserver<CreateTeamStep>>();

            LoadLeagues();
        }

        private async Task LoadLeagues()
        {
            Leagues = new ObservableCollection<LeagueModel>(await _leagueModelService.GetAllAsync());
        }

        #region IObservable
        public void OnLeagueSubmitted()
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(new CreateTeamStep()
                {
                    CurrentStep = CreateTeamStepType.LeagueSelection,
                    NextStep = CreateTeamStepType.NameSelection,
                    IsSubmitted = SelectedLeague is not null
                });
            }
        }

        public IDisposable Subscribe(IObserver<CreateTeamStep> observer)
        {
            if(! _observers.Contains(observer))
                _observers.Add(observer);

            return new Unsubscriber<CreateTeamStep>(_observers, observer);
        }
        #endregion
    }
}
