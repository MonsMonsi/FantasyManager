using AutoMapper;
using FantasyManager.Application.Models.Data;
using FantasyManager.Application.Services.Interfaces;
using FantasyManager.Domain.Entities;
using FantasyManager.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.Application.Services
{
    public class SeasonModelService : ModelServiceBase, ISeasonModelService
    {
        private readonly IDataService<Season> _seasonDataService;

        public SeasonModelService(IDataService<Season> seasonDataService, IMapper mapper) : base(mapper)
        {
            _seasonDataService = seasonDataService;
        }

        public async Task<SeasonModel> CreateAsync(SeasonModel seasonModel)
        {
            var createdSeason = await _seasonDataService.CreateAsync(Mapper.Map<Season>(seasonModel));

            return Mapper.Map<SeasonModel>(createdSeason);
        }
    }
}
