using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FantasyManager.Domain.Entities
{
    public class League : DomainObject
    {
        [Column(TypeName = "nvarchar"), MaxLength(100), Required]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(100), Required]
        public string Country { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(250), Required]
        public string Logo { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(250), Required]
        public string Flag { get; set; }

        [JsonIgnore]
        public virtual IList<Team> Teams { get; set; } = new List<Team>();

        [JsonIgnore]
        public virtual IList<Season> Seasons { get; set; } = new List<Season>();
    }
}
