using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.Application.Models.Data
{
    public class SeasonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LeagueId { get; set; }
        public LeagueModel League { get; set; }
        public virtual IList<UserTeamModel> UserTeams { get; set; } = new List<UserTeamModel>();
    }
}
