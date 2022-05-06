using FantasyManager.Application.Models.Observable;
using FantasyManager.WPF.Common.Behaviors.DragDrop.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.WPF.ViewModels.Controls
{
    public class UserTeamFormationViewModel : ViewModelBase
    {
        #region OnChangeProperties
        private ObservableCollection<PlayerDraftModel> _drafts;
        public ObservableCollection<PlayerDraftModel> Drafts
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
            Drafts = new ObservableCollection<PlayerDraftModel>(new PlayerDraftModel[18]);
        }

        public void DraftPlayer(PlayerDraftModel player)
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
    }
}
