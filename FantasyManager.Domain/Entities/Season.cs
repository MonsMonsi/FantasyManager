using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FantasyManager.Domain.Entities
{
    public class Season : DomainObject
    {
        [Column(TypeName = "nvarchar"), MaxLength(100), Required]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual IList<UserTeam> UserTeams { get; set; } = new List<UserTeam>();
    }
}
