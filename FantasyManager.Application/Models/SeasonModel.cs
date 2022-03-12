﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.Application.Models
{
    public class SeasonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<UserTeamModel> UserTeams { get; set; } = new List<UserTeamModel>();
    }
}
