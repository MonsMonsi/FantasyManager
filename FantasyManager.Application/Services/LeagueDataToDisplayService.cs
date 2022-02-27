using AutoMapper;
using FantasyManager.Application.Services.Interfaces;
using FantasyManager.Data;
using FantasyManager.Domain.Entities;
using FantasyManager.Domain.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.Application.Services
{
    public class LeagueDataToDisplayService : ILeagueDataToDisplayService
    {
        private readonly IDataService<League> _leagueService;

        public LeagueDataToDisplayService(IDataService<League> leagueService)
        {
            _leagueService = leagueService;
        }
        public async Task<ObservableCollection<League>> GetAllAsync()
        {
            var leagues = await _leagueService.GetAllAsync();

            var observableLeagues = new ObservableCollection<League>(leagues);

            return observableLeagues;
        }
    }
}
