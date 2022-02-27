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
    public class PlayerDataService : IPlayerService
    {
        private readonly FootballContextFactory _contextFactory;
        private readonly NonQueryDataService<Player> _nonQueryDataService;

        public PlayerDataService(FootballContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Player>(contextFactory);
        }
        public async Task<Player> CreateAsync(Player player)
        {
            return await _nonQueryDataService.CreateAsync(player);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _nonQueryDataService.DeleteAsync(id);
        }

        public async Task<IEnumerable<Player>> GetAllAsync()
        {
            using (FootballContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Player> players = await context.Set<Player>()
                    .Include(p => p.Team)
                    .ThenInclude(t => t.League)
                    .ToListAsync();

                return players;
            }
        }

        public async Task<Player> GetByIdAsync(int id)
        {
            using (FootballContext context = _contextFactory.CreateDbContext())
            {
                Player? player = await context.Set<Player>().FirstOrDefaultAsync(p => p.Id == id);

                return player;
            }
        }

        public async Task<IEnumerable<Player>> GetByLeagueAsync(int leagueId)
        {
            using (FootballContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Player> players = await context.Set<Player>()
                    .Include(p => p.Team)
                    .ThenInclude(t => t.League)
                    .Where(p => p.Team.LeagueId == leagueId)
                    .ToListAsync();

                return players;
            }
        }

        public async Task<IEnumerable<Player>> GetByTeamAsync(int teamId)
        {
            using (FootballContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Player> players = await context.Set<Player>()
                    .Include(p => p.Team)
                    .Where(p => p.TeamId == teamId)
                    .ToListAsync();

                return players;
            }
        }

        public async Task<Player> UpdateAsync(int id, Player player)
        {
            return await _nonQueryDataService.UpdateAsync(id, player);
        }
    }
}
