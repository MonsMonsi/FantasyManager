using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FantasyManager.Domain.Entities
{
    public class User : DomainObject
    {
        [Column(TypeName = "nvarchar"), MaxLength(50), Required]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(20), Required]
        public string Password { get; set; }

        [JsonIgnore]
        public virtual IList<UserTeam> UserTeams { get; set; } = new List<UserTeam>();
    }
}
