using AutoMapper;
using FantasyManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.Application.Services
{
    public abstract class ServiceBase
    {
        protected readonly IMapper Mapper;

        public ServiceBase(IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}
