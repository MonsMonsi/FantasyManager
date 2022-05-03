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
            Drafts = new ObservableCollection<PlayerDraftViewModel>(new PlayerDraftViewModel[18]);
            
        }

        #region IDropable
        Type IDropable.DataType => typeof(ViewModelBase);

        public void Drop(object data, int index = -1)
        {
            if(data is PlayerDraftViewModel playerToDraft)
            {
                DraftPlayer(playerToDraft);  
            }
        }

        private void DraftPlayer(PlayerDraftViewModel player)
        {
            var index = -1;

            switch (player.Position)
            {
                case "Goalkeeper":
                    index = GetFreePosition(0, 1);

                    if (index > -1)
                    {
                        Drafts[index] = player;
                    }
                    break;
                case "Defender":
                    index = GetFreePosition(2, 7);

                    if (index > -1)
                    {
                        Drafts[index] = player;
                    }
                    break;
                case "Midfielder":
                    index = GetFreePosition(8, 13);

                    if (index > -1)
                    {
                        Drafts[index] = player;
                    }
                    break;
                case "Attacker":
                    index = GetFreePosition(14, 17);

                    if (index > -1)
                    {
                        Drafts[index] = player;
                    }
                    break;
                default:
                    break;
            }
        }

        private int GetFreePosition(int start, int end)
        {
            var noFreePosition = -1;

            for (int i = start; i <= end; i++)
            {
                if (Drafts[i] is null)
                    return i;
            }

            return noFreePosition;
        }
        #endregion
    }
}
