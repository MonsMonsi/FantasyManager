using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace FantasyManager.Application.Models.Observable
{
    public class PlayerDraftModel
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        // public int MarketValue { get; set; }
    }
}
