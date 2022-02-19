using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FantasyManager.Domain.Entities
{
    public class Team : DomainObject
    {
        [Column(TypeName = "nvarchar"), MaxLength(100), Required]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(250), Required]
        public string Logo { get; set; }
        public int LeagueId { get; set; }

        [ForeignKey("LeagueId")]
        public virtual League League { get; set; }

        public int VenueId { get; set; }

        [ForeignKey("VenueId")]
        public virtual Venue Venue { get; set; }

        [JsonIgnore]
        public virtual IList<Player> Players { get; set; } = new List<Player>();
    }
}
