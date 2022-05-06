using FantasyManager.Application.Models.Data;
using FantasyManager.Application.Models.Observable;
using FantasyManager.WPF.Common.Commands;
using FantasyManager.WPF.ViewModels.Controls;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FantasyManager.WPF.ViewModels
{
    public class DraftTeamViewModel : ViewModelBase
    {
        public PlayerDraftListViewModel PlayerDraftListViewModel { get; set; }
        public UserTeamFormationViewModel UserTeamFormationViewModel { get; set; }

        #region OnChangeProperties

        private int _leagueId;
        public int LeagueId
        {
            get { return _leagueId; }
            set
            {
                _leagueId = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands

        public ICommand HandleDropCommand { get; }
        #endregion

        public DraftTeamViewModel(PlayerDraftListViewModel playerDraftListViewModel, UserTeamFormationViewModel userTeamFormationViewModel)
        {
            PlayerDraftListViewModel = playerDraftListViewModel;
            UserTeamFormationViewModel = userTeamFormationViewModel;

            PlayerDraftListViewModel.LeagueId = 39;

            HandleDropCommand = new RelayCommand<object>(HandleDrop);
        }

        private void HandleDrop(object dragSource)
        {
            if (dragSource is PlayerDraftModel player)
            {
                PlayerDraftListViewModel.RemovePlayerFromList(player);

                UserTeamFormationViewModel.DraftPlayer(player);
            }
        }
    }
}
