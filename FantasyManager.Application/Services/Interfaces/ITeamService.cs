using FantasyManager.Application.Models.Data;
using FantasyManager.Application.Models.Observable;
using System.Collections.ObjectModel;

namespace FantasyManager.Application.Services.Interfaces
{
    public interface ITeamService
    {
        Task<ObservableCollection<TeamModel>> GetAllAsync();
        Task<ObservableCollection<TeamLogoModel>> GetAllLogosAsync();
    }
}
