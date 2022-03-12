using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.Application.Models.Data
{
    public class TeamModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public int LeagueId { get; set; }
        public virtual LeagueModel League { get; set; }
        public int VenueId { get; set; }
        public virtual VenueModel Venue { get; set; }
        public virtual IList<PlayerModel> Players { get; set; } = new List<PlayerModel>();
    }
}
