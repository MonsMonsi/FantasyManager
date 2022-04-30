using FantasyManager.Application.Models.Observable.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace FantasyManager.Application.Models.Observable
{
    public class PlayerListViewItemModel : IDragable
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public Header Header { get; set; }
        public SubHeader SubHeader { get; set; }

        #region IDragable

        public Type DataType => typeof(PlayerListViewItemModel);

        public void Remove(object i)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
