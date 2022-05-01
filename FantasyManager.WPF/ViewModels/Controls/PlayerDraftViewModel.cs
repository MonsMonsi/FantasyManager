using FantasyManager.Application.Models.Observable;
using FantasyManager.Application.Services.Interfaces;
using FantasyManager.WPF.Common.Behaviors.DragDrop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.WPF.ViewModels.Controls
{
    public class PlayerDraftViewModel : ViewModelBase, IDragable, IDropable
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }

        public PlayerDraftViewModel() { }
        public PlayerDraftViewModel(PlayerDraftModel playerDraftModel)
        {
            Id = playerDraftModel.Id;
            Image = playerDraftModel.Image;
            FullName = playerDraftModel.FullName;
            Position = playerDraftModel.Position;
        }

        #region IDragable
        Type IDragable.DataType => typeof(PlayerDraftViewModel);

        public void Remove(object i)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region IDropable

        Type IDropable.DataType => typeof(PlayerDraftViewModel);
        public void Drop(object data, int index = -1)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
