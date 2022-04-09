using AutoMapper;
using FantasyManager.Application.Models.Data;
using FantasyManager.Application.Services.Interfaces;
using FantasyManager.Domain.Entities;
using FantasyManager.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.Application.Services
{
    public class UserTeamModelService : ModelServiceBase, IUserTeamModelService
    {
        private readonly IUserTeamService _userTeamService;

        public UserTeamModelService(IUserTeamService userTeamService, IMapper mapper) : base(mapper)
        {
            _userTeamService = userTeamService;
        }

        public async Task<bool> CreateAsync(UserTeamModel userTeamModel)
        {
            var createdUserTeam = _userTeamService.CreateAsync(Mapper.Map<UserTeam>(userTeamModel));

            return createdUserTeam is not null;
        }

        public async Task<UserTeamModel> GetByNameAsync(string userTeamName)
        {
            var storedUserTeam = Mapper.Map<UserTeamModel>(_userTeamService.GetByNameAsync(userTeamName));

            return storedUserTeam;
        }
    }
}
