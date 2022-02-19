using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyManager.Domain.Entities
{
    public class UserTeamSquad : DomainObject
    {
        public int UserTeamId { get; set; }

        [ForeignKey("UserTeamId")]
        public virtual UserTeam UserTeam { get; set; }
        public int PlayerId { get; set; }

        [ForeignKey("PlayerId")]
        public virtual Player Player { get; set; }
    }
}
