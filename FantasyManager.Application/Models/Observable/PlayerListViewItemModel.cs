using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.Application.Models.Observable
{
    public class PlayerListViewItemModel
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public IEnumerable<string> Header { get; set; }
        public IEnumerable<string> SubHeader { get; set; }
    }
}
