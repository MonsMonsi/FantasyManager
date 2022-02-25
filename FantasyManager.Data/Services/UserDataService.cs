using FantasyManager.Data.Services.Common;
using FantasyManager.Domain.Entities;
using FantasyManager.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.Data.Services
{
    public class UserDataService : IUserService
    {
        private readonly FootballContextFactory _contextFactory;
        private readonly NonQueryDataService<User> _nonQueryDataService;

        public UserDataService(FootballContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<User>(contextFactory);
        }

        public async Task<User> CreateAsync(User user)
        {
            return await _nonQueryDataService.CreateAsync(user);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _nonQueryDataService.DeleteAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            using (FootballContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<User> entities = await context.Set<User>().ToListAsync();

                return entities;
            }
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            using (FootballContext context = _contextFactory.CreateDbContext())
            {
                return await context.Users.FirstOrDefaultAsync(u => u.Email == email);
            }
        }

        public async Task<User> GetByIdAsync(int id)
        {
            using (FootballContext context = _contextFactory.CreateDbContext())
            {
                User entity = await context.Set<User>().FirstOrDefaultAsync(e => e.Id == id);

                return entity;
            }
        }

        public async Task<User> GetByNameAsync(string userName)
        {
            using (FootballContext context = _contextFactory.CreateDbContext())
            {
                return await context.Users.FirstOrDefaultAsync(u => u.Name == userName);
            }
        }

        public async Task<User> UpdateAsync(int id, User user)
        {
            return await _nonQueryDataService.UpdateAsync(id, user);
        }
    }
}
