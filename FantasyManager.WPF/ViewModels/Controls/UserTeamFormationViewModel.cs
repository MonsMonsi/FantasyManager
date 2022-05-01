using FantasyManager.WPF.Common.Behaviors.DragDrop.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.WPF.ViewModels.Controls
{
    public class UserTeamFormationViewModel : ViewModelBase, IDropable
    {
        #region OnChangeProperties
        private ObservableCollection<PlayerDraftViewModel> _drafts;
        public ObservableCollection<PlayerDraftViewModel> Drafts
        {
            get { return _drafts; }
            set
            {
                _drafts = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public UserTeamFormationViewModel()
        {
            Drafts = new ObservableCollection<PlayerDraftViewModel>(new PlayerDraftViewModel[17]);
            
        }

        #region IDropable
        Type IDropable.DataType => typeof(PlayerDraftViewModel);

        public void Drop(object data, int index = -1)
        {
            var draftedPlayer = data as PlayerDraftViewModel;

        }
        #endregion
    }
}
