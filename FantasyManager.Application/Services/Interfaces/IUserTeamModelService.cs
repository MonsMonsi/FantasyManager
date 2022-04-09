using FantasyManager.Application.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.Application.Services.Interfaces
{
    public interface IUserTeamModelService
    {
        Task<UserTeamModel> GetByNameAsync(string userTeamName);
        Task<bool> CreateAsync(UserTeamModel userTeamModel);
    }
}
