using FantasyManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.Domain.Services
{
    public interface IUserService : IDataService<User>
    {
        Task<User> GetByNameAsync(string userName);
        Task<User> GetByEmailAsync(string email);
    }
}
