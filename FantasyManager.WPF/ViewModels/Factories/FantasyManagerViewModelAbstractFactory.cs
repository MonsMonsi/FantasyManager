using FantasyManager.WPF.Enums;
using FantasyManager.WPF.ViewModels.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.WPF.ViewModels.Factories
{
    public class FantasyManagerViewModelAbstractFactory : IFantasyManagerViewModelAbstractFactory
    {
        private readonly IFantasyManagerViewModelFactory<LoginViewModel> _loginViewModelFactory;
        private readonly IFantasyManagerViewModelFactory<HomeViewModel> _homeViewModelFactory;
        private readonly IFantasyManagerViewModelFactory<CreateTeamViewModel> _createTeamViewModelFactory;
        private readonly IFantasyManagerViewModelFactory<DraftTeamViewModel> _draftTeamViewModelFactory;
        private readonly IFantasyManagerViewModelFactory<PlaySeasonViewModel> _playSeasonViewModelFactory;

        public FantasyManagerViewModelAbstractFactory
            (IFantasyManagerViewModelFactory<LoginViewModel> loginViewModelFactory,
            IFantasyManagerViewModelFactory<HomeViewModel> homeViewModelFactory, 
            IFantasyManagerViewModelFactory<CreateTeamViewModel> createTeamViewModelFactory, 
            IFantasyManagerViewModelFactory<DraftTeamViewModel> draftTeamViewModelFactory, 
            IFantasyManagerViewModelFactory<PlaySeasonViewModel> playSeasonViewModelFactory)
        {
            _loginViewModelFactory = loginViewModelFactory;
            _homeViewModelFactory = homeViewModelFactory;
            _createTeamViewModelFactory = createTeamViewModelFactory;
            _draftTeamViewModelFactory = draftTeamViewModelFactory;
            _playSeasonViewModelFactory = playSeasonViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Login:
                    return _loginViewModelFactory.CreateViewModel();
                case ViewType.Home:
                    return _homeViewModelFactory.CreateViewModel();
                case ViewType.CreateTeam:
                    return _createTeamViewModelFactory.CreateViewModel();
                case ViewType.DraftTeam:
                    return _draftTeamViewModelFactory.CreateViewModel();
                case ViewType.PlaySeason:
                    return _playSeasonViewModelFactory.CreateViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
