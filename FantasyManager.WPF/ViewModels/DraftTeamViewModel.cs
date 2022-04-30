using FantasyManager.Application.Models.Data;
using FantasyManager.Application.Models.Observable;
using FantasyManager.Application.Models.Observable.Interfaces;
using FantasyManager.Application.Services.Interfaces;
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
        public PlayerListDraftViewModel PlayerListDraftViewModel { get; set; }

        #region OnChangeProperties

        private ObservableCollection<PlayerListViewItemModel>? _players;
        public ObservableCollection<PlayerListViewItemModel>? Players
        {
            get { return _players; }
            set
            {
                _players = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands

        private ICommand _onPlayerDroppedCommand;
        public ICommand OnPlayerDroppedCommand 
        {
            get { return _onPlayerDroppedCommand ?? (_onPlayerDroppedCommand = new RelayCommand<object>(OnPlayerDropped)); }
            set
            {
                _onPlayerDroppedCommand = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public DraftTeamViewModel(PlayerListDraftViewModel playerListDraftViewModel)
        {
            PlayerListDraftViewModel = playerListDraftViewModel;
        }

        private void OnPlayerDropped(object parameter)
        {
            var test = parameter.ToString();
        }
    }
}
