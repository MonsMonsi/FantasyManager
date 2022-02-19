using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FantasyManager.Domain.Entities
{
    [ComplexType]
    public class Birth
    {
        [Column("BirthDate", TypeName = "nvarchar"), MaxLength(20), Required]
        public string Date { get; set; }

        [Column("BirthCountry", TypeName = "nvarchar"), MaxLength(100), Required]
        public string Country { get; set; }

        [Column("BirthPlace", TypeName = "nvarchar"), MaxLength(100), Required]
        public string Place { get; set; }
    }
    public class Player : DomainObject
    {
        [Column(TypeName = "nvarchar"), MaxLength(100), Required]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(100), Required]
        public string LastName { get; set; }

        public Birth Birth { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(100), Required]
        public string Nationality { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(10), Required]
        public string Height { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(10), Required]
        public string Weight { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(30), Required]
        public string Position { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(250), Required]
        public string Photo { get; set; }

        [Column(TypeName = "bit"), Required]
        public bool Active { get; set; }
        public int TeamId { get; set; }

        [ForeignKey("TeamId")]
        public Team Team { get; set; }

        [JsonIgnore]
        public virtual IList<UserTeamSquad> UserTeamSquads { get; set; } = new List<UserTeamSquad>();
    }
}
