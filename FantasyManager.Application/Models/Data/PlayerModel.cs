using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.Application.Models.Data
{
    public class BirthModel
    {
        public string Date { get; set; }
        public string Country { get; set; }
        public string Place { get; set; }
    }
    public class PlayerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public BirthModel Birth { get; set; }
        public string Nationality { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Position { get; set; }
        public string Photo { get; set; }
        public bool Active { get; set; }
        public int TeamId { get; set; }
        public TeamModel Team { get; set; }
        public virtual IList<UserTeamSquadModel> UserTeamSquads { get; set; } = new List<UserTeamSquadModel>();
    }
}
