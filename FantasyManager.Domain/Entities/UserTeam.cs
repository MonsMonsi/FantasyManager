using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FantasyManager.Domain.Entities
{
    public class UserTeam : DomainObject
    {
        [Column(TypeName = "nvarchar"), MaxLength(100), Required]
        public string Name { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual  User User { get; set; }
        public int SeasonId { get; set; }

        [ForeignKey("SeasonId")]
        public virtual Season Season { get; set; }

        [JsonIgnore]
        public virtual IList<UserTeamSquad> UserTeamSquads { get; set; } = new List<UserTeamSquad>();
    }
}
