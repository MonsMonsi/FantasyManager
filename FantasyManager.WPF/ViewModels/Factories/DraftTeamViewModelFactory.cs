using FantasyManager.WPF.ViewModels.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.WPF.ViewModels.Factories
{
    public class DraftTeamViewModelFactory : IFantasyManagerViewModelFactory<DraftTeamViewModel>
    {
        public DraftTeamViewModel CreateViewModel()
        {
            return new DraftTeamViewModel();
        }
    }
}
