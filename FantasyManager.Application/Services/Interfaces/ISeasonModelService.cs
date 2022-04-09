using FantasyManager.Application.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.Application.Services.Interfaces
{
    public interface ISeasonModelService
    {
        Task<SeasonModel> CreateAsync(SeasonModel seasonModel);
    }
}
