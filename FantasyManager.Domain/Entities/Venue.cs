using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FantasyManager.Domain.Entities
{
    public class Venue : DomainObject
    {
        [Column(TypeName = "nvarchar"), MaxLength(100), Required]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(100), Required]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(100), Required]
        public string City { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(20), Required]
        public string Capacity { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(250), Required]
        public string Image { get; set; }

        [JsonIgnore]
        public virtual IList<Team> Teams { get; set; } = new List<Team>();

    }
}
