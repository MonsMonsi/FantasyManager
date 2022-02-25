using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FantasyManager.Domain.Entities
{
    public class User : DomainObject
    {
        [Column(TypeName = "nvarchar"), MaxLength(50), Required]
        public string Name { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(150), Required]
        public string Email { get; set; }

        [Column(TypeName = "DateTime2"), Required]
        public DateTime JoinedAt { get; set; }

        [JsonIgnore]
        public virtual IList<UserTeam> UserTeams { get; set; } = new List<UserTeam>();
    }
}
