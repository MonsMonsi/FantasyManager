using FantasyManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.Domain.Services
{
    public interface IUserTeamService : IDataService<UserTeam>
    {
        Task<UserTeam> GetByNameAsync(string userTeamName);
        Task<IEnumerable<UserTeam>> GetByUserAsync(User user);
    }
}
