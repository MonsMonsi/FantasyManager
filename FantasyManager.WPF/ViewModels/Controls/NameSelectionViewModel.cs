using FantasyManager.WPF.Common.IObservable;
using FantasyManager.WPF.Enums;
using FantasyManager.WPF.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.WPF.ViewModels.Controls
{
    public class NameSelectionViewModel : ViewModelBase, IObservable<CreateTeamStep>
    {
        List<IObserver<CreateTeamStep>> _observers;

        #region OnChangeProperties
        private string _userTeamName;
        public string UserTeamName
        {
            get => _userTeamName;
            set
            {
                _userTeamName = value;
                OnNameSubmitted();
                OnPropertyChanged();
            }
        }
        #endregion

        public NameSelectionViewModel()
        {
            _observers = new List<IObserver<CreateTeamStep>>();
        }

        #region IObservable
        public void OnNameSubmitted()
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(new CreateTeamStep()
                {
                    CurrentStep = CreateTeamStepType.NameSelection,
                    NextStep = CreateTeamStepType.LogoSelection,
                    IsSubmitted = UserTeamName is not null && UserTeamName.Trim() is not ""
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
