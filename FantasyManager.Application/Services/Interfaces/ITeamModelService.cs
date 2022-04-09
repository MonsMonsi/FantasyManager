using FantasyManager.Application.Models.Data;
using FantasyManager.Application.Models.Observable;
using System.Collections.ObjectModel;

namespace FantasyManager.Application.Services.Interfaces
{
    public interface ITeamModelService
    {
        Task<IEnumerable<TeamModel>> GetAllAsync();
        Task<IEnumerable<TeamLogoModel>> GetAllLogosAsync();
    }
}
