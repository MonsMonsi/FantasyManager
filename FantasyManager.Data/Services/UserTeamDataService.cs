using FantasyManager.Data.Services.Common;
using FantasyManager.Domain.Entities;
using FantasyManager.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.Data.Services
{
    public class UserTeamDataService : IUserTeamService
    {
        private readonly FootballContextFactory _contextFactory;
        private readonly NonQueryDataService<UserTeam> _nonQueryDataService;

        public UserTeamDataService(FootballContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<UserTeam>(contextFactory);
        }

        public async Task<UserTeam> CreateAsync(UserTeam userTeam)
        {
            return await _nonQueryDataService.CreateAsync(userTeam);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _nonQueryDataService.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserTeam>> GetAllAsync()
        {
            using (FootballContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<UserTeam> userTeams = await context.Set<UserTeam>()
                    .Include(ut => ut.User)
                    .ToListAsync();

                return userTeams;
            }
        }

        public async Task<UserTeam> GetByIdAsync(int id)
        {
            using (FootballContext context = _contextFactory.CreateDbContext())
            {
                UserTeam? userTeam = await context.Set<UserTeam>().FirstOrDefaultAsync(ut => ut.Id == id);

                return userTeam;
            }
        }

        public async Task<UserTeam> GetByNameAsync(string userTeamName)
        {
            using (FootballContext context = _contextFactory.CreateDbContext())
            {
                UserTeam? userTeam = await context.Set<UserTeam>().FirstOrDefaultAsync(ut => ut.Name == userTeamName);

                return userTeam;
            }
        }

        public async Task<IEnumerable<UserTeam>> GetByUserAsync(User user)
        {
            using (FootballContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<UserTeam> userTeams = await context.Set<UserTeam>()
                    .Include(ut => ut.User)
                    .Where(ut => ut.User == user)
                    .ToListAsync();

                return userTeams;
            }
        }

        public async Task<UserTeam> UpdateAsync(int id, UserTeam userTeam)
        {
            return await _nonQueryDataService.UpdateAsync(id, userTeam);
        }
    }
}
