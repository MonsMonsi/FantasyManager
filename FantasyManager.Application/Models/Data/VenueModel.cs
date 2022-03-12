using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.Application.Models.Data
{
    public class VenueModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Capacity { get; set; }
        public string Image { get; set; }
        public virtual IList<TeamModel> Teams { get; set; } = new List<TeamModel>();
    }
}
