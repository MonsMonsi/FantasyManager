using FantasyManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.Domain.Services
{
    public interface IPlayerService : IDataService<Player>
    {
        Task<IEnumerable<Player>> GetByLeagueAsync(int leagueId);
        Task<IEnumerable<Player>> GetByTeamAsync(int teamId);
    }
}
