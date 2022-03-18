using AutoMapper;
using FantasyManager.Application.Models.Data;
using FantasyManager.Application.Models.Observable;
using FantasyManager.Application.Services.Interfaces;
using FantasyManager.Domain.Entities;
using FantasyManager.Domain.Services;
using System.Collections.ObjectModel;

namespace FantasyManager.Application.Services
{
    public class TeamModelService : ModelServiceBase, ITeamModelService
    {
        private readonly IDataService<Team> _teamDataService;

        public TeamModelService(IDataService<Team> teamDataService, IMapper mapper) : base(mapper)
        {
            _teamDataService = teamDataService;
        }

        public async Task<ObservableCollection<TeamModel>> GetAllAsync()
        {
            var teams = Mapper.Map<List<TeamModel>>(await _teamDataService.GetAllAsync());

            var observableTeams = new ObservableCollection<TeamModel>(teams);

            return observableTeams;
        }

        public async Task<ObservableCollection<TeamLogoModel>> GetAllLogosAsync()
        {
            var teams = Mapper.Map<List<TeamModel>>(await _teamDataService.GetAllAsync());

            var observableTeamLogos = new ObservableCollection<TeamLogoModel>();

            foreach (var team in teams)
            {
                var teamLogo = new TeamLogoModel()
                {
                    Id = team.Id,
                    Logo = team.Logo
                };

                observableTeamLogos.Add(teamLogo);
            }

            return observableTeamLogos;
        }
    }
}
