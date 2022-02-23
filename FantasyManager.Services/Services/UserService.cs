using AutoMapper;
using FantasyManager.Data;
using FantasyManager.Domain.Entities;
using FantasyManager.Services.Models.Data;
using FantasyManager.Services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FantasyManager.Services.Services
{
    public class UserService : ServiceBase, IUserService
    {
        public UserService(FootballContextFactory contextFactory, IMapper mapper) : base(contextFactory, mapper) { }

        public async Task<UserModel> AddNew(UserModel user)
        {
            if (UserIsNew(user))
            {
                var userToDb = Mapper.Map<User>(user);

                await Context.Users.AddAsync(userToDb);
                await Context.SaveChangesAsync();

                var userFromDb = await Context.Users.Where(u => u.Name == user.Name).FirstOrDefaultAsync();

                return Mapper.Map<UserModel>(userFromDb);
            };

            return null;
        }

        public async Task<UserModel> Login(UserModel user)
        {
            if (UserIsValid(user))
            {
                var userFromDb = await Context.Users.Where(u => u.Name == user.Name).FirstOrDefaultAsync();

                return Mapper.Map<UserModel>(userFromDb);
            };

            return null;
        }

        private bool UserIsNew(UserModel user)
        {
            var userFromDb = Context.Users.Where(u => u.Name == user.Name).FirstOrDefault();

            if (userFromDb == null)
            {
                return true;
            }

            return false;
        }

        private bool UserIsValid(UserModel user)
        {
            var userFromDb = Context.Users.Where(u => u.Name == user.Name).FirstOrDefault();

            if (userFromDb == null || userFromDb.Password != user.Password)
            {
                return false;
            }

            return true;
        }
    }
}
