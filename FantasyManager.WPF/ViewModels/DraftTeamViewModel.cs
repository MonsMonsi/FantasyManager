using FantasyManager.Application.Models.Data;
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

        #endregion

        public DraftTeamViewModel(PlayerDraftListViewModel playerDraftListViewModel, UserTeamFormationViewModel userTeamFormationViewModel)
        {
            PlayerDraftListViewModel = playerDraftListViewModel;
            UserTeamFormationViewModel = userTeamFormationViewModel;

            PlayerDraftListViewModel.LeagueId = 39;
        }
    }
}
