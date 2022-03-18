using FantasyManager.Application.Models.Data;
using FantasyManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.Application.Services.Interfaces
{
    public interface ILeagueModelService
    {
        Task<ObservableCollection<LeagueModel>> GetAllAsync();
    }
}
