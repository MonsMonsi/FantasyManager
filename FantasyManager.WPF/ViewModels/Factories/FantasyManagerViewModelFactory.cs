using FantasyManager.WPF.Enums;
using FantasyManager.WPF.ViewModels.Factories.Interfaces;
using System;

namespace FantasyManager.WPF.ViewModels.Factories
{
    public class FantasyManagerViewModelFactory : IFantasyManagerViewModelFactory
    {
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<CreateTeamViewModel> _createCreateTeamViewModel;
        private readonly CreateViewModel<DraftTeamViewModel> _createDraftTeamViewModel;
        private readonly CreateViewModel<PlaySeasonViewModel> _createPlaySeasonViewModel;

        public FantasyManagerViewModelFactory(CreateViewModel<LoginViewModel> createLoginViewModel,
            CreateViewModel<HomeViewModel> createHomeViewModel, 
            CreateViewModel<CreateTeamViewModel> createCreateTeamViewModel,
            CreateViewModel<DraftTeamViewModel> createDraftTeamViewModel,
            CreateViewModel<PlaySeasonViewModel> createPlaySeasonViewModel)
        {
            _createLoginViewModel = createLoginViewModel;
            _createHomeViewModel = createHomeViewModel;
            _createCreateTeamViewModel = createCreateTeamViewModel;
            _createDraftTeamViewModel = createDraftTeamViewModel;
            _createPlaySeasonViewModel = createPlaySeasonViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Login:
                    return _createLoginViewModel();
                case ViewType.Home:
                    return _createHomeViewModel();
                case ViewType.CreateTeam:
                    return _createCreateTeamViewModel();
                case ViewType.DraftTeam:
                    return _createDraftTeamViewModel();
                case ViewType.PlaySeason:
                    return _createPlaySeasonViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
