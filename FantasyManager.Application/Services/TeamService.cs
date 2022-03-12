using FantasyManager.Application.Models;
using FantasyManager.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.Application.Services
{
    public class TeamService : ITeamService
    {
        public Task<ObservableCollection<TeamModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
