using FantasyManager.Application.Models;
using System.Collections.ObjectModel;

namespace FantasyManager.Application.Services.Interfaces
{
    public interface ITeamService
    {
        Task<ObservableCollection<TeamModel>> GetAllAsync();
    }
}
