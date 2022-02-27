using FantasyManager.Application.Services.Interfaces;
using FantasyManager.Domain.Entities;
using System.Collections.ObjectModel;

namespace FantasyManager.WPF.ViewModels
{
    public class CreateTeamViewModel : ViewModelBase
    {
        private ObservableCollection<League>? _leagues;
        public ObservableCollection<League>? Leagues
        {
            get { return _leagues; }
            set
            {
                _leagues = value;
                OnPropertyChanged();
            }
        }

        private readonly ILeagueDataToDisplayService _leagueService;

        public CreateTeamViewModel(ILeagueDataToDisplayService leagueService)
        {
            _leagueService = leagueService;
            LoadLeagues();
        }

        private async void LoadLeagues()
        {
            Leagues = await _leagueService.GetAllAsync();
        }
    }
}
