﻿using FantasyManager.Application.Services.Interfaces;
using FantasyManager.Domain.Entities;
using FantasyManager.Domain.Services;
using FantasyManager.WPF.ViewModels.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.WPF.ViewModels.Factories
{
    public class CreateTeamViewModelFactory : IFantasyManagerViewModelFactory<CreateTeamViewModel>
    {
        private readonly ILeagueService _leagueService;

        public CreateTeamViewModelFactory(ILeagueService leagueService)
        {
            _leagueService = leagueService;
        }

        public CreateTeamViewModel CreateViewModel()
        {
            return new CreateTeamViewModel(_leagueService);
        }
    }
}
